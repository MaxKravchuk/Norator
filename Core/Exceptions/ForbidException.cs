﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class ForbidException : Exception
    {
        public new string Message { get; set; } = string.Empty;

        public ForbidException()
        {
            Message = "You don't have permission to access / on this server";
        }

        public ForbidException(string message) : base(message)
        {
            Message = message;
        }

        public ForbidException(string message, Exception inner) : base(message, inner)
        {
            Message = message;
        }
    }
}
