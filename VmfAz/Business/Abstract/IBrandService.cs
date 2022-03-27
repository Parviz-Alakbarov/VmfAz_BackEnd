using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs.BrandDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        Task<IResult> Add(BrandPostDto brandPostDto);
        Task<IResult> Update(int id,BrandPostDto brandPostDto);
        Task<IResult> Delete(int brandId);
        Task<IDataResult<List<Brand>>> GetAll();
        Task<IDataResult<Brand>> GetBrandById(int brandId);
        Task<IDataResult<List<BrandWithNameDto>>> GetBrandsOnlyWithName();
        Task<IDataResult<List<BrandWithImageDto>>> GetBrandsWithImage();
        Task<IDataResult<BrandDetailDto>> GetBrandDetail(int brandId);

    }
}
