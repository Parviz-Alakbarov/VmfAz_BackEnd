using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.JWT;
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
        Task<IDataResult<AppUser>> Login(UserLoginDto userForLoginDto);
        Task<IResult> ChangePassword(UserChangePasswordDto userForChangePasswordDto);
        Task<IResult> UserExists(string email);
        Task<IDataResult<AccessToken>> CreateAccessToken(AppUser user);


        Task<IResult> ResetPassword(UserResetPasswordDto userForResetPasswordDto);
    }
}
