using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private readonly Type _validatorType;

        public ValidationAspect(Type validationType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validationType))
            {
                throw new System.Exception($"{validationType} is invalid Validation class!");
            }
            _validatorType = validationType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var methodParamethers = invocation.Arguments.Where(p => p.GetType() == entityType);
            foreach (var paramether in methodParamethers)
            {
                ValidationTool.Validate(validator, paramether);
            }
        }
    }
}
