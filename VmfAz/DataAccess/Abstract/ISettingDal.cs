using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ISettingDal
    {
        List<Setting> GetAll();
        Setting GetByKey(string key);
        void Update(Setting setting);
        List<Country> GetCountries();
        List<City> GetCitiesByCountry(int countryId);
    }
}
