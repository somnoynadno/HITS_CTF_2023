﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardApp.Models.Exceptions
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException() { }
        public InvalidCredentialsException(string? message) : base(message) { }
        public InvalidCredentialsException(string message, Exception? innerException) : base(message, innerException) { }
    }
}
