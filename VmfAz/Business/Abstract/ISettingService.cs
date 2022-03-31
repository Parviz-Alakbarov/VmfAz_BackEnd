using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Concrete.ProductEntries;
using Entities.DTOs;
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
        Task<IDataResult<List<ProductFunctionality>>> GetProductFuntionalities();
    }
}
