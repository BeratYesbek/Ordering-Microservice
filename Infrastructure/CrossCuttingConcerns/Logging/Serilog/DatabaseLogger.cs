using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Infrastructure.CrossCuttingConcerns.Logging.Serilog
{
    public class DatabaseLogger : ILoggerServiceBase
    {
        private readonly ILogger? _logger;
        public DatabaseLogger()
        {
            if (ServiceTool.ServiceProvider != null) 
                _logger = ServiceTool.ServiceProvider.GetService<ILogger>();
        }
        public void Verbose(LogDetail logDetail)
        {
            throw new NotImplementedException();
        }

        public void Fatal(LogDetail logDetail)
        {
            throw new NotImplementedException();
        }

        public void Info(LogDetail logDetail)
        {
            _logger?.Information("{FullName}{UserId}{MethodName}", logDetail.FullName, logDetail.UserId, logDetail.MethodName);
        }

        public void Warn(LogDetail logDetail)
        {
            throw new NotImplementedException();
        }

        public void Debug(LogDetail logDetail)
        {
            throw new NotImplementedException();
        }

        public void Error()
        {
            throw new NotImplementedException();
        }
    }
}
