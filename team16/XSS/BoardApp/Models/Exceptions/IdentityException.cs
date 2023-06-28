using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardApp.Models.Exceptions
{
    public class IdentityException : Exception
    {
        public List<IdentityError>? Errors { get; set; }

        public IdentityException() { }
        public IdentityException(List<IdentityError> errors)
        {
            Errors = errors;
        }
        public IdentityException(string? message) : base(message) { }
        public IdentityException(string? message, List<IdentityError> errors) : this(message) { Errors = errors; }
        public IdentityException(string message, Exception? innerException) : base(message, innerException) { }
        public IdentityException(string message, List<IdentityError> errors, Exception? innerException) : this(message, innerException) { Errors = errors; }
    }
}
