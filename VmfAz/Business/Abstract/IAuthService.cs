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
        IDataResult<AppUser> Register(UserRegisterDto userForRegisterDto, string password);
        IDataResult<AppUser> Login(UserLoginDto userForLoginDto);
        IResult ChangePassword(UserChangePasswordDto userForChangePasswordDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(AppUser user);
    }
}
