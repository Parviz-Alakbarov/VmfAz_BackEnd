 using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation.UserValidators;
using Core.Aspects.Autofac.Authorization;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.BusinessMotor;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private ICountryService _countryService;
        private ICityService _cityService;
        private IUserOperationClaimService _operationClaimService;

        public AuthManager(IUserService userService,
                            ITokenHelper tokenHelper,
                            ICityService cityService,
                            ICountryService countryService, IUserOperationClaimService operationClaimService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _cityService = cityService;
            _countryService = countryService;
            _operationClaimService = operationClaimService;
        }
        [ValidationAspect(typeof(UserRegisterDtoValidator))]
        public async Task<IDataResult<AppUser>> Register(UserRegisterDto userRegisterDto)
        {
            var result = BusinessRules.Run(
                await UserExists(userRegisterDto.Email),
                await CheckCountryExist(userRegisterDto.CountryId),
                await CheckCityExist(userRegisterDto.CountryId, userRegisterDto.CityId));

            if (result != null)
                return new ErrorDataResult<AppUser>(result.Message);

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
            await _operationClaimService.Add((await _userService.GetByMail(user.Email)).Data.Id,3);
            return new SuccessDataResult<AppUser>(user, Messages.UserRegistered);
        }

        [ValidationAspect(typeof(UserLoginDtoValidator))]
        public async Task<IDataResult<AppUser>> Login(UserLoginDto userForLoginDto)
        {
            var userToCheck = await _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck.Data == null)
            {
                return new ErrorDataResult<AppUser>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<AppUser>(Messages.PasswordError);
            }

            return new SuccessDataResult<AppUser>(userToCheck.Data, Messages.SuccessfullLogin);
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
            throw new NotImplementedException();
        }

        [ValidationAspect(typeof(UserLoginDtoValidator))]
        [AuthorizeOperation("AppUser")]
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
            _userService.Update(user.Data);

            var claims = await _userService.GetClaims(user.Data);
            var accessToken = _tokenHelper.CreateToken(user.Data, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);

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

