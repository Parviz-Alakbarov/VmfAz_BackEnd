using Business.Abstract;
using Business.Constants;
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
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IUserOperationClaimDal _userOperationClaim;
        private readonly IUserService _userService;


        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaim, IUserService userService)
        {
            _userOperationClaim = userOperationClaim;
            _userService = userService;
        }

        public async Task<IResult> Add(int userId, int claimId)
        {

            if (await _userService.GetById(userId)==null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            UserOperationClaim userOperationClaim = new UserOperationClaim
            {
                AppUserId = userId,
                OperationClaimId = 3
            };
            await _userOperationClaim.Add(userOperationClaim);
            return new SuccessResult();

        }

        public Task<IResult> Delete(int claimId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<UserOperationClaim>>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
