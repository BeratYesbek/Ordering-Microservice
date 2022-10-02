using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.CrossCuttingConcerns.Logging;
using MediatR;

namespace Infrastructure.Pipelines.Logging
{
    public class LoggingBehavior<TRequest, TResponse> : LoggingRequest<TRequest>, IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILoggerServiceBase _logger;
        public LoggingBehavior(ILoggerServiceBase logger)
        {
            _logger = logger;
        }
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var logDetail = GetLogDetail(request);
            _logger.Info(logDetail);
            return next();
        }
    }
}
