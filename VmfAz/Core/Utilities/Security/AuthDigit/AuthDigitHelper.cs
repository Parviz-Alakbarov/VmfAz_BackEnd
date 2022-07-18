using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.IoC;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.AuthDigit
{
    public static class AuthDigitHelper
    {
        private static readonly ICacheManager _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        public static int GenerateCode(string email)
        {
            Random random = new Random();
            int num = random.Next(100000, 999999);
            _cacheManager.Add(email, new temp { Code = num,Count = 0 },1);
            return num;
        }

        public static IResult ValidateCode(string email, int code)
        {
            temp result = (temp)_cacheManager.Get(email);
            if (result == null)
            {
                return new ErrorResult("This user not requested for forgot password service!");
            }
            if (result.Code !=code)
            {
                result.Count++;
                return new ErrorResult($"Invalid code. You have {3-result.Count} more chance. Check your email and try again.");
            }
            if (result.Count>=3)
            {
                return new ErrorResult("3 chance for reset password have exceeded.");
            }
            return new SuccessResult();
        }
    }
    public class temp
    {
        public int Code { get; set; }
        public int Count{ get; set; }
    }
}
