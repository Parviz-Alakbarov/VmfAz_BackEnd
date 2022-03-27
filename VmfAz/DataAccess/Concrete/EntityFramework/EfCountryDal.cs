using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCountryDal : ICountryDal
    {
        public async Task<bool> CheckCountryExists(int countryId)
        {
            using (VmfAzContext context = new VmfAzContext())
            {
                var result = from country in context.Countries
                             where country.Id == countryId
                             select country;
                return await result.SingleOrDefaultAsync() != null;
            }
        }
    }
}
