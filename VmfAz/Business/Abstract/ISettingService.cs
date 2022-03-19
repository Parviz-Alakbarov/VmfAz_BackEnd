using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
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
        IDataResult<List<Setting>> GetAll();
        IDataResult<Setting> GetByKey(string key);
        IResult Update(SettingPostDto settingPostDto);
        IDataResult<List<Country>> GetCountries();
        IDataResult<List<City>> GetCitiesByCountry(int countryId);
    }
}
