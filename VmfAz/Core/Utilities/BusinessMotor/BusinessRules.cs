using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.BusinessMotor
{
    public static class BusinessRules
    {
        public static IResult Run(params IResult[] businessMethods)
        {
            foreach (var method in businessMethods)
            {
                if (!method.Success)
                    return method;
            }
            return null;
        }
    }
}
