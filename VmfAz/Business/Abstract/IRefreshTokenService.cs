using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRefreshTokenService
    {
        Task<IResult> Add(RefreshTokenPostDto refreshTokenDto );
        Task<IResult> Delete(Guid id);
        Task<IResult> DeleteAll(int userId);
        Task<IDataResult<RefreshToken>> GetByToken(string token);
       
    }
}
