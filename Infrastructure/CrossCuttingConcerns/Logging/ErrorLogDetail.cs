using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CrossCuttingConcerns.Logging
{
    public class ErrorLogDetail : LogDetail
    {
        public string? ExceptionMessage { get; set; }
        public Exception? Exception { get; set; }
    }
}
