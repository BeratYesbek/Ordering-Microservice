using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utilities.Exceptions
{
    public class CustomExceptionDetail : Exception
    {
        public int StatusCode { get; set; }
        public bool Status { get; set; } = false;

        public CustomExceptionDetail()
        {
            
        }

        public CustomExceptionDetail(int statusCode,string message) : base(message)
        {
            
        }
    }
}
