using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<IDataResult<List<OperationClaim>>> GetClaims(AppUser user)
        {
            return new SuccessDataResult<List<OperationClaim>>(await _userDal.GetClaims(user));
        }

        public async Task<IResult> Add(AppUser user)
        {
            await _userDal.Add(user);
            return new SuccessResult();
        }

        public async Task<IDataResult<AppUser>> GetByMail(string email)
        {
            return new SuccessDataResult<AppUser>(await _userDal.Get(u => u.Email == email));
        }

        public async Task<IResult> Update(AppUser user)
        {
            await _userDal.Update(user);
            return new SuccessResult();
        }

        public async Task<IDataResult<AppUser>> GetById(int userId)
        {
            var result = await _userDal.Get(x=>x.Id== userId);
          
            return new SuccessDataResult<AppUser>(result);
        }

        public async Task<IDataResult<UserGetDto>> GetUserInGetDto(int userId)
        {
            return new SuccessDataResult<UserGetDto>(await _userDal.GetUserInGetDto(userId));
        }
    }
}
