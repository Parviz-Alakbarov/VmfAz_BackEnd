using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.JWT;
using Entities.DTOs.AuthDtos;
using Entities.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<AppUser>> Register(UserRegisterDto userForRegisterDto);
        Task<IDataResult<TokensModel>> Login(UserLoginDto userForLoginDto);
        Task<IResult> ChangePassword(UserChangePasswordDto userForChangePasswordDto);
        Task<IResult> UserExists(string email);
        Task<IResult> UpdateUser(UserUpdateDto userUpdateDto);

        Task<IDataResult<AccessToken>> CreateAccessToken(AppUser user);
        IDataResult<AccessToken> CreateRefreshToken(AppUser user);
        Task<IResult> Logout(string auth);
        Task<IDataResult<TokensModel>> RefreshToken(UserForRefreshTokenDto userForRefreshTokenDto);
        Task<IResult> SetClaimToUser(UserSetClaimDto setClaimDto);
        Task<IDataResult<UserGetDto>> GetUser();


        Task<IResult> ResetPassword(UserResetPasswordDto userForResetPasswordDto);
        Task<IResult> ForgotPasswordConfirmation(ForgotPasswordConfirmDto forgotPasswordConfirmDto);

    }
}
