using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.BrandDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBrandDal : IEntityRepository<Brand>
    {
        Task<BrandDetailDto> GetBrandDetail(int id);
        Task<List<BrandWithImageDto>> GetBrandsWithImage();
        Task<List<BrandWithNameDto>> GetBrandsOnlyWithName();
    }
}
