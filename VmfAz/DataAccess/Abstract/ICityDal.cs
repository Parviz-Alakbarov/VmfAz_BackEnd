using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICityDal
    {
        bool CheckCityExists(int id);
        bool CheckCityExistsOnCountry(int countryId, int cityId);
        List<City> GetCitiesByCountry(int countryId);
    }
}
