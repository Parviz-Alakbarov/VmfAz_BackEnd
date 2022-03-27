using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICityService
    {
        Task<IResult> CheckCityExists(int cityId);
        Task<IResult> CheckCityExistsOnCountry(int countryId, int cityId);
        Task<IDataResult<List<City>>> GetCitiesByCountry(int countryId);
    }
}
