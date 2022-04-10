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
    public class EfUserDal : EfEntityRepositoryBase<AppUser, VmfAzContext>, IUserDal
    {
        public async Task<List<OperationClaim>> GetClaims(AppUser appUser)
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.AppUserId == appUser.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return await result.ToListAsync();
            }
        }

        public async Task<UserGetDto> GetUserInGetDto(int userId)
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var result = from u in context.AppUsers
                             where u.IsDeleted == false && u.Id == userId
                             select new UserGetDto
                             {
                                 Id = u.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Address = u.Address,
                                 CityId = u.CityId,
                                 CountryId = u.CountryId,
                                 Email = u.Email ,
                                 PhoneNumber = u.PhoneNumber,
                             };
                return await result.SingleOrDefaultAsync();
            }
        }
    }
}
