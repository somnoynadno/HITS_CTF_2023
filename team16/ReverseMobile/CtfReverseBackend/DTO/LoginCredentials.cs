using System.ComponentModel.DataAnnotations;

namespace CtfReverseBackend.DTO
{
    public class LoginCredentials
    {
        [Required]
        public string Username { get; set; }
        [Required] 
        public string Password { get; set; }
    }
}
