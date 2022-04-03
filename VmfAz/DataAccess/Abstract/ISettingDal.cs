using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Concrete.ProductEntries;
using Entities.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ISettingDal
    {
        Task<List<Setting>> GetAll();
        Task<Setting> GetByKey(string key);
        Task Update(Setting setting);
        Task<List<Country>> GetCountries();
        Task<List<City>> GetCitiesByCountry(int countryId);
        Task<List<ProductEntryDto>> GetProductFunctionalities();
        Task<List<ProductEntryDto>> GetProductWaterResistances();
        Task<List<ProductEntryDto>> GetProductStyles();
        Task<List<ProductEntryDto>> GetProductMechanisms();
        Task<List<ProductEntryDto>> GetProductGlassTypes();
        Task<List<ProductEntryDto>> GetProductCaseSizes();
        Task<List<ProductEntryDto>> GetProductCaseShapes();
        Task<List<ProductEntryDto>> GetProductCaseMaterials();
        Task<List<ProductEntryDto>> GetProductBeltTypes();
        Task<List<ProductEntryDto>> GetGenders();
        Task<List<Color>> GetColors();

    }
}
