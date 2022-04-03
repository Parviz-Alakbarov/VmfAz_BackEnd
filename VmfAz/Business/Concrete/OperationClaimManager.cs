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
    public class OperationClaimManager : IOperationClaimService
    {
        private readonly IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        public async Task<IDataResult<List<OperationClaimGetDto>>> GetAll()
        {
            return new SuccessDataResult<List<OperationClaimGetDto>> (await _operationClaimDal.GetOperationClaimsInGetDto());
        }

        public async Task<IDataResult<OperationClaimGetDto>> GetById(int id)
        {
            return new SuccessDataResult<OperationClaimGetDto>(await _operationClaimDal.GetOperatonClaimInGetDto(id));
        }
    }
}
