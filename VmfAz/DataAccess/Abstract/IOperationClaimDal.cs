using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IOperationClaimDal: IEntityRepository<OperationClaim>
    {
        Task<List<OperationClaimGetDto>> GetOperationClaimsInGetDto();
        Task<OperationClaimGetDto> GetOperatonClaimInGetDto(int claimId);

    }
}
