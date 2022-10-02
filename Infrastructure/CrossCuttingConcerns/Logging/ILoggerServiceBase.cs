using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace Infrastructure.CrossCuttingConcerns.Logging
{
    public interface ILoggerServiceBase
    {
        public void Verbose(LogDetail logDetail);
        public void Fatal(LogDetail logDetail);
        public void Info(LogDetail logDetail);
        public void Warn(LogDetail logDetail);
        public void Debug(LogDetail logDetail);
        public void Error();
    }
}
