using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardApp.Models.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() { }
        public NotFoundException(string? message) : base(message) { }
        public NotFoundException(string message, Exception? innerException) : base(message, innerException) { }

        public static NotFoundException GenerateDefault<T>(Guid id)
        {
            return new NotFoundException($"{typeof(T).Name} '{id}' does not exist");
        }

        public static NotFoundException GenerateDefault<T>()
        {
            return new NotFoundException($"Requested {typeof(T).Name} does not exist");
        }
    }
}
