using System.ComponentModel.DataAnnotations;

namespace BoardApp.Models.DTO
{
    public class LoginDTO
    {
        public string Username { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public List<BoardShortDTO> Boards { get; set; }
    }

    public class CreateUserDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; }
    }

    public class EditUserDTO
    {
        [MinLength(3)]
        [MaxLength(50)]
        public string Username { get; set; }
    }

    public class UserShortDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
    }
}
