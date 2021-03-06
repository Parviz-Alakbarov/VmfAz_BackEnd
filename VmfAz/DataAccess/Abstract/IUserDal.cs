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
    public interface IUserDal : IEntityRepository<AppUser>
    {
        Task<List<OperationClaim>> GetClaims(AppUser appUser);
        Task<UserGetDto> GetUserInGetDto(int userId);
    }
}
