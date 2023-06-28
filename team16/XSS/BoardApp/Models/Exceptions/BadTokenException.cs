using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardApp.Models.Exceptions
{
    public class BadTokenException : Exception
    {
        public BadTokenException() { }
        public BadTokenException(string? message) : base(message) { }
        public BadTokenException(string message, Exception? innerException) : base(message, innerException) { }
    }
}
