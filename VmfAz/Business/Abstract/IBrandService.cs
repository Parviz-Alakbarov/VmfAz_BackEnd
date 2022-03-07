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
        IResult Add(BrandPostDto brandPostDto);
        IResult Update(int id,BrandPostDto brandPostDto);
        IResult Delete(int brandId);
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetBrandById(int brandId);
        

    }
}
