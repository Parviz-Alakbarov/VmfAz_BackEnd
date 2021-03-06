using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CityManager : ICityService
    {
        private readonly ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        public async Task<IResult> CheckCityExists(int cityId)
        {
            return await _cityDal.CheckCityExists(cityId)? new SuccessResult():new ErrorResult();
        }

        public async Task<IResult> CheckCityExistsOnCountry(int countryId, int cityId)
        {
            return await _cityDal.CheckCityExistsOnCountry(countryId,cityId) ? new SuccessResult() : new ErrorResult();
        }

        public async Task<IDataResult<List<City>>> GetCitiesByCountry(int countryId)
        {
            List<City> result = await _cityDal.GetCitiesByCountry(countryId);
            if (result==null)
            {
                return new ErrorDataResult<List<City>>(Messages.CityNotExist);
            }
            return new SuccessDataResult<List<City>>(result);
        }
    }
}
