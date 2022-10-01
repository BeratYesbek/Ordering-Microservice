using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Infrastructure.Utilities.Exceptions
{
    public class CustomValidationException : CustomExceptionDetail
    {
        public object? Errors { get; set; }

        public CustomValidationException()
        {
            
        }

        public CustomValidationException(int statusCode,string message, object errors) : base(statusCode,message)
        {
            Errors = errors;
        }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
