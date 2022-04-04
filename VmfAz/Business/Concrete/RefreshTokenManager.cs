using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entities.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RefreshTokenManager : IRefreshTokenService
    {
        private readonly IRefreshTokenDal _refreshTokenDal;

        public RefreshTokenManager(IRefreshTokenDal refreshTokenDal)
        {
            _refreshTokenDal = refreshTokenDal;
        }

        public async Task<IResult> Add(RefreshTokenPostDto refreshTokenDto)
        {
            RefreshToken token = new RefreshToken
            {
                Id = Guid.NewGuid(),
                Token = refreshTokenDto.Token,
                UserId = refreshTokenDto.UserId
            };
             await _refreshTokenDal.Add(token);
            return new SuccessResult(Messages.RefreshTokenAdded);
        }

        public async Task<IResult> Delete( Guid id)
        {
            var result = await _refreshTokenDal.Get(x=>x.Id == id);
            if (result == null)
            {
                return new ErrorResult(Messages.RefreshTokenNotFound);
            }

            await _refreshTokenDal.Delete(result);
            return new SuccessResult(Messages.RefreshTokenDeleted);
        }

        public async Task<IResult> DeleteAll(int userId)
        {
            await _refreshTokenDal.DeleteAll(userId);
            return new SuccessResult();
        }


        public async Task<IDataResult<RefreshToken>> GetByToken(string token)
        {
            return new SuccessDataResult<RefreshToken>(await _refreshTokenDal.Get(x => x.Token == token));
        }
    }
}
