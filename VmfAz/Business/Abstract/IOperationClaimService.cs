using Core.Utilities.Results.Abstract;
using Entities.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOperationClaimService
    {
        Task<IDataResult<List<OperationClaimGetDto>>> GetAll();
        Task<IDataResult<OperationClaimGetDto>> GetById(int id);
    }
}
