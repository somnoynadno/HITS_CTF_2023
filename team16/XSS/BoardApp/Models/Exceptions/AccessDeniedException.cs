﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardApp.Models.Exceptions
{
    public class AccessDeniedException : Exception
    {
        public AccessDeniedException() { }
        public AccessDeniedException(string? message) : base(message) { }
        public AccessDeniedException(string message, Exception? innerException) : base(message, innerException) { }
    }
}
