using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CrossCuttingConcerns.Logging
{
    public class LogDetail
    {
        public string? FullName { get; set; }
        public string? MethodName { get; set; }
        public string? UserId { get; set; }
        public string? Claims { get; set; }
        public string? Email { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
