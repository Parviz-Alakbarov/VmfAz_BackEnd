using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation.UserValidators;
using Core.Aspects.Autofac.Authorization;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.BusinessMotor;
using Core.Utilities.MailHelper;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs.UserDTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private static readonly string templatesDirectory = Environment.CurrentDirectory + "\\wwwroot\\assets\\templates";

        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOperationClaimService _operationClaimService;
        private readonly IEmailService _emailService;

        public AuthManager(IUserService userService,
                            ITokenHelper tokenHelper,
                            ICityService cityService,
                            ICountryService countryService,
                            IUserOperationClaimService userOperationClaimService,
                            IRefreshTokenService refreshTokenService,
                            IHttpContextAccessor httpContextAccessor,
                            IOperationClaimService operationClaimService, 
                            IEmailService emailService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _cityService = cityService;
            _countryService = countryService;
            _userOperationClaimService = userOperationClaimService;
            _refreshTokenService = refreshTokenService;
            _httpContextAccessor = httpContextAccessor;
            _operationClaimService = operationClaimService;
            _emailService = emailService;
        }
        [ValidationAspect(typeof(UserRegisterDtoValidator))]
        public async Task<IDataResult<AppUser>> Register(UserRegisterDto userRegisterDto)
        {
            IResult result = BusinessRules.Run(
                await UserExists(userRegisterDto.Email),
                await CheckCountryExist(userRegisterDto.CountryId),
                await CheckCityExist(userRegisterDto.CountryId, userRegisterDto.CityId));

            if (result != null)
                return new ErrorDataResult<AppUser>(null,result.Message);

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new AppUser
            {
                Email = userRegisterDto.Email,
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Address = userRegisterDto.Address,
                PhoneNumber = userRegisterDto.PhoneNumber,
                CityId = userRegisterDto.CityId,
                CountryId = userRegisterDto.CountryId,
                IsDeleted = false
            };
            await _userService.Add(user);
            await _userOperationClaimService.Add((await _userService.GetByMail(user.Email)).Data.Id,3);
            return new SuccessDataResult<AppUser>(user, Messages.UserRegistered);
        }


        [ValidationAspect(typeof(UserLoginDtoValidator))]
        public async Task<IDataResult<TokensModel>> Login(UserLoginDto userForLoginDto)
        {
            var userToCheck = await _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck.Data == null)
            {
                return new ErrorDataResult<TokensModel>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<TokensModel>(Messages.PasswordError);
            }

            var tokensModelResult = await CreateTokensModel(userToCheck.Data);
            if (!tokensModelResult.Success)
            {
                return tokensModelResult;
            }    

            return new SuccessDataResult<TokensModel>(tokensModelResult.Data, Messages.SuccessfullLogin);
        }

        [AuthorizeOperation("AppUser")]
        [ValidationAspect(typeof(UserUpdateDtoValidator))]
        public async Task<IResult> UpdateUser(UserUpdateDto userUpdateDto)
        {
            IResult result = BusinessRules.Run(
                await CheckCountryExist(userUpdateDto.CountryId),
                await CheckCityExist(userUpdateDto.CountryId, userUpdateDto.CityId));

            if (result != null)
                return new ErrorResult(result.Message);

            var userId = _httpContextAccessor.HttpContext.User.GetNameIdentifier()[0];
            if (!Int32.TryParse(userId, out int id))
                return new ErrorResult(Messages.UserNotFound);

            var userResult = (await _userService.GetById(id)).Data;
            if (userResult == null)
                return new ErrorResult(Messages.UserNotFound);

            //AppUser user = userResult;
            if (userResult.Email != userUpdateDto.Email)
            {
                var emailResult = (await _userService.GetByMail(userUpdateDto.Email)).Data;
                if (emailResult != null)
                    return new ErrorResult(Messages.UserAlreadyExists);
            }
            userResult.Email = userUpdateDto.Email;
            userResult.FirstName = userUpdateDto.FirstName;
            userResult.LastName = userUpdateDto.LastName;
            userResult.Address = userUpdateDto.Address;
            userResult.PhoneNumber = userUpdateDto.PhoneNumber;
            userResult.CityId = userUpdateDto.CityId;
            userResult.CountryId = userUpdateDto.CountryId;
            await _userService.Update(userResult);
            return new SuccessResult(Messages.UserRegistered);
        }

        [AuthorizeOperation("AppUser")]
        public async Task<IDataResult<UserGetDto>> GetUser()
        {
            var userId = _httpContextAccessor.HttpContext.User.GetNameIdentifier()[0];

            if (!Int32.TryParse(userId, out int id))
            {
                return new ErrorDataResult<UserGetDto>(Messages.UserNotFound);
            }

            var result = await _userService.GetUserInGetDto(id);
            if (result == null)
            {
                return new ErrorDataResult<UserGetDto>(Messages.UserNotFound);
            }
            return new SuccessDataResult<UserGetDto>(result.Data,Messages.UserDataFound);

        }

        public async Task<IResult> UserExists(string email)
        {
            if ((await _userService.GetByMail(email)).Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public async Task<IDataResult<AccessToken>> CreateAccessToken(AppUser user)
        {
            var claims = await _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public async Task<IResult> ResetPassword(UserResetPasswordDto userForRPDto)
        {
            AppUser user = (await _userService.GetByMail(userForRPDto.Email)).Data;
            if (user == null)
            {
                return new ErrorResult(Messages.AuthCodeSendedToEmail); 
            }

            EmailMessage emailMessage = new EmailMessage();

            string text = System.IO.File.ReadAllText(templatesDirectory + "/ForgotPassword.html");

            text = text.Replace("[AuthDigit]", "232323");

            emailMessage.Body = text;
            emailMessage.Subject = "This is test email";
            EmailAddress adress = new EmailAddress { Address = "parvizja@code.edu.az", Name = "parviz" };
            EmailAddress adress2 = new EmailAddress { Address = "smtp.test2022@hotmail.com", Name = "sadiq" };
            emailMessage.FromAdresses.Add(adress2);
            emailMessage.ToAdresses.Add(adress);

            await _emailService.SendEmail(emailMessage);

            return new SuccessResult(Messages.AuthCodeSendedToEmail);

        }

        [AuthorizeOperation("AppUser,Admin,SuperAdmin")]
        [ValidationAspect(typeof(UserLoginDtoValidator))]
        public async Task<IResult> ChangePassword(UserChangePasswordDto userForChangePasswordDto)
        {
            var user = await _userService.GetByMail(userForChangePasswordDto.Email);
            if (user.Data == null)
                return new ErrorResult(Messages.UserNotFound);

            if (!HashingHelper.VerifyPasswordHash(userForChangePasswordDto.CurrentPassword, user.Data.PasswordHash, user.Data.PasswordSalt))
            {
                return new ErrorDataResult<AppUser>(Messages.ChangePasswordError);
            }

            HashingHelper.CreatePasswordHash(userForChangePasswordDto.NewPassword, out var passwordHash, out var passwordSalt);
            user.Data.PasswordHash = passwordHash;
            user.Data.PasswordSalt = passwordSalt;
            await _userService.Update(user.Data);

            var claims = await _userService.GetClaims(user.Data);
            var accessToken = _tokenHelper.CreateToken(user.Data, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);

        }

        [AuthorizeOperation("SuperAdmin")]
        public async Task<IResult> SetClaimToUser(UserSetClaimDto setClaimDto)
        {
            var user = await _userService.GetByMail(setClaimDto.Email);

            if (user == null)
                return new ErrorResult(Messages.UserNotFound);

            var claimResult = await _operationClaimService.GetById(setClaimDto.ClaimId);
            if (claimResult == null)
                return new ErrorResult(Messages.ClaimNotFound);

            await _userOperationClaimService.Add(user.Data.Id, claimResult.Data.Id);
            return new SuccessResult(Messages.ClaimAddedToUser);
        }



        [AuthorizeOperation("AppUser,Admin,SuperAdmin")]
        public async Task<IResult> Logout(string auth)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.GetNameIdentifier()[0];

            if (!Int32.TryParse(roleClaims, out int id))
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            await _refreshTokenService.DeleteAll(id);
            return new SuccessResult(Messages.UserLoggedOut);
        }

        [ValidationAspect(typeof(UserForRefreshTokenDtoValidator))]
        public async Task<IDataResult<TokensModel>> RefreshToken(UserForRefreshTokenDto userForRefreshTokenDto)
        {
            bool isValidRefreshToken = _tokenHelper.ValidateRefreshToken(userForRefreshTokenDto.RefreshToken);
            if (!isValidRefreshToken)
            {
                return new ErrorDataResult<TokensModel>(Messages.InvalidRefreshToken);
            }

            RefreshToken refreshToken = (await _refreshTokenService.GetByToken(userForRefreshTokenDto.RefreshToken)).Data;
            if (refreshToken == null)
            {
                return new ErrorDataResult<TokensModel>(Messages.InvalidRefreshToken);
            }

            AppUser appUser = (await _userService.GetById(refreshToken.UserId)).Data;
            if (appUser == null)
            {
                return new ErrorDataResult<TokensModel>(Messages.UserNotFound);
            }
            await _refreshTokenService.Delete(refreshToken.Id);

            var tokensModelResult = await CreateTokensModel(appUser);
            if (!tokensModelResult.Success)
            {
                return tokensModelResult;
            }
            return new SuccessDataResult<TokensModel>(tokensModelResult.Data, Messages.TokenRefreshed);
        }

        private async Task<IDataResult<TokensModel>> CreateTokensModel(AppUser user)
        {
            var result = await CreateAccessToken(user);
            if (!result.Success)
            {
                return new ErrorDataResult<TokensModel>(result.Message);
            }
            var refreshToken = _tokenHelper.CreateRefreshToken(user);
            if (refreshToken == null)
            {
                return new ErrorDataResult<TokensModel>(Messages.RefreshTokenCreationError);
            }

            await _refreshTokenService.Add(new RefreshTokenPostDto { Token = refreshToken.Token, UserId = user.Id, });

            TokensModel model = new TokensModel
            {
                AccessToken = result.Data,
                RefreshToken = refreshToken
            };
            return new SuccessDataResult<TokensModel>(model);
        }

        public IDataResult<AccessToken> CreateRefreshToken(AppUser user)
        {
            var accessToken = _tokenHelper.CreateRefreshToken(user);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.RefreshTokenCreated);
        }


        //BusinessRules
        private async Task<IResult> CheckCountryExist(int countryId)
        {
            return await _countryService.CheckCountryExists(countryId);
        }
        private async Task<IResult> CheckCityExist(int countryId, int cityId)
        {
            return await _cityService.CheckCityExistsOnCountry(countryId, cityId);
        }
    }
}

