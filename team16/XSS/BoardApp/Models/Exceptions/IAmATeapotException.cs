using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardApp.Models.Exceptions
{
    public class IAmATeapotException : Exception
    {
        public IAmATeapotException() { }
        public IAmATeapotException(string? message) : base(message) { }
        public IAmATeapotException(string message, Exception? innerException) : base(message, innerException) { }
    }
}
