using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardApp.Models.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException() { }
        public AlreadyExistsException(string? message) : base(message) { }
        public AlreadyExistsException(string message, Exception? innerException) : base(message, innerException) { }
        public static AlreadyExistsException GenerateDefault<T>(Guid id)
        {
            return new AlreadyExistsException($"{typeof(T).Name} already exists");
        }
    }
}
