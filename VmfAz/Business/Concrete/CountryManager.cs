using Business.Abstract;
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
    public class CountryManager : ICountryService
    {
        private readonly ICountryDal _countryDal;

        public CountryManager(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }

        public async Task<IResult> CheckCountryExists(int countryId)
        {
            return await _countryDal.CheckCountryExists(countryId) ? new SuccessResult() : new ErrorResult();
        }
    }
}
