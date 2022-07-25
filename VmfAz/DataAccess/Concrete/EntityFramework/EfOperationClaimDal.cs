using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs.UserDTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOperationClaimDal : EfEntityRepositoryBase<OperationClaim, VmfAzContext>, IOperationClaimDal
    {
        public async Task<List<OperationClaimGetDto>> GetOperationClaimsInGetDto()
        {
            using (VmfAzContext context = new())
            {
                var result = from operationClaim in context.OperationClaims
                             select new OperationClaimGetDto
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name
                             };
                return await result.ToListAsync();
            }
        }

        public async Task<OperationClaimGetDto> GetOperatonClaimInGetDto(int claimId)
        {
            using (VmfAzContext context = new())
            {
                var result = from operationClaim in context.OperationClaims
                             where operationClaim.Id == claimId
                             select new OperationClaimGetDto
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name
                             };
                return await result.SingleOrDefaultAsync();
            }
        }
    }
}
