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
        Task<bool> CheckCityExists(int id);
        Task<bool> CheckCityExistsOnCountry(int countryId, int cityId);
        Task<List<City>> GetCitiesByCountry(int countryId);
    }
}
