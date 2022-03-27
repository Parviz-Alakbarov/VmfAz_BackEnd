﻿using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
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

        public IResult Add(AppUser user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public async Task<IDataResult<AppUser>> GetByMail(string email)
        {
            return new SuccessDataResult<AppUser>(await _userDal.Get(u => u.Email == email));
        }

        public IResult Update(AppUser user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }

        public async Task<IDataResult<AppUser>> GetById(int userId)
        {
            var result = await _userDal.Get(x=>x.Id== userId);
          
            return new SuccessDataResult<AppUser>(result);
        }
    }
}
