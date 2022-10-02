using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection service, ICoreModule[] modules)
        {
            foreach (var coreModule in modules)
            {
                coreModule.Load(service);
            }

            return ServiceTool.Create(service);
        }
    }
}
