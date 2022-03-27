using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
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
        IResult Add(AppUser user);
        IResult Update(AppUser user);
        Task<IDataResult<AppUser>> GetByMail(string email);
        Task<IDataResult<AppUser>> GetById(int userId);
    }
}
