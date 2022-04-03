using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Concrete.ProductEntries;
using Entities.DTOs;
using Entities.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISettingService
    {
        Task<IDataResult<List<Setting>>> GetAll();
        Task<IDataResult<Setting>> GetByKey(string key);
        Task<IResult> Update(SettingPostDto settingPostDto);
        Task<IDataResult<List<Country>>> GetCountries();
        Task<IDataResult<List<City>>> GetCitiesByCountry(int countryId);
        Task<IDataResult<List<ProductEntryDto>>> GetProductFuntionalities();
        Task<IDataResult<List<ProductEntryDto>>> GetProductBeltTypes();
        Task<IDataResult<List<ProductEntryDto>>> GetProductCaseMaterials();
        Task<IDataResult<List<ProductEntryDto>>> GetProductCaseShapes();
        Task<IDataResult<List<ProductEntryDto>>> GetProductCaseSizes();
        Task<IDataResult<List<ProductEntryDto>>> GetProductGlassTypes();
        Task<IDataResult<List<ProductEntryDto>>> GetProductMechanisms();
        Task<IDataResult<List<ProductEntryDto>>> GetProductStyles();
        Task<IDataResult<List<ProductEntryDto>>> GetProductWaterResistances();
        Task<IDataResult<List<ProductEntryDto>>> GetGenders();
        Task<IDataResult<List<Color>>> GetColors();


    }
}
