using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private readonly int _duration;
        private readonly ICacheManager _cacheManager;
        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();

        }
        public override void Intercept(IInvocation invocation)
        {
            string methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();

            var cacheMemoryKey = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<<Null>>"))})";
            if (_cacheManager.Exists(cacheMemoryKey))
            {
                invocation.ReturnValue = _cacheManager.Get(cacheMemoryKey);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(cacheMemoryKey, invocation.ReturnValue, _duration);
        }
    }
}
