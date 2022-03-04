using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCityDal : ICityDal
    {
        public bool CheckCityExists(int id)
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var result = from city in context.Cities
                             where city.Id == id
                             select city;
                return result != null;
            }
        }

        public bool CheckCityExistsOnCountry(int countryId, int cityId)
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var result = from city in context.Cities
                             where city.CountryId == countryId && city.Id == cityId
                             select city;
                return result != null;
            }
        }

        public List<City> GetCitiesByCountry(int countryId)
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var result = from city in context.Cities

                             where city.CountryId == countryId
                             select new City { Id = city.Id, Name = city.Name, CountryId = city.CountryId };
                return result.ToList();
            }
        }
    }
}
