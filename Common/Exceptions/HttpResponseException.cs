using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class HttpResponseException : Exception
    {
        public int Status { get; set; }
        public object Value { get; set; }
    }
}
