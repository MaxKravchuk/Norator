using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public new string Message { get; set; } = string.Empty;

        public UnauthorizedException()
        {
            Message = "Access is denied due to invalid credentials";
        }

        public UnauthorizedException(string message) : base(message)
        {
            Message = message;
        }

        public UnauthorizedException(string message, Exception inner) : base(message, inner)
        {
            Message = message;
        }
    }
}
