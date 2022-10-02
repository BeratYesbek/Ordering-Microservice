using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.CrossCuttingConcerns.Logging;
using Infrastructure.CrossCuttingConcerns.Logging.Serilog;
using Infrastructure.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ILoggerServiceBase, DatabaseLogger>();
        }
    }
}
