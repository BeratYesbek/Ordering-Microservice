using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.CrossCuttingConcerns.Logging;

namespace Infrastructure.Pipelines.Logging
{
    public abstract class LoggingRequest<TRequest>
    {
        public virtual LogDetail GetLogDetail(TRequest request)
        {
            LogDetail logDetail = new()
            {
                FullName = request?.GetType().Name,
                DateTime = DateTime.Now
            };
            return logDetail;
        }
    }
}
