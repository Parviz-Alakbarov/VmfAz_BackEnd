using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<List<OperationClaim>>> GetClaims(AppUser user);
        Task<IResult> Add(AppUser user);
        Task<IResult> Update(AppUser user);
        Task<IDataResult<AppUser>> GetByMail(string email);
        Task<IDataResult<AppUser>> GetById(int userId);
        Task<IDataResult<UserGetDto>> GetUserInGetDto(int userId);
        
    }
}
