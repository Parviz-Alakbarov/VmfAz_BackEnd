using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Concrete.ProductEntries;
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
        Task<List<ProductFunctionality>> GetProductFunctionalities();

    }
}
