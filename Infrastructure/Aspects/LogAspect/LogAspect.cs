using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Aspects.LogAspect
{
    public class LogAspect : Attribute
    {
        public LogAspect(Type logger)
        {
            Console.WriteLine("Hello World");
        }
    }
}
