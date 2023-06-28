using System.ComponentModel.DataAnnotations;

namespace BoardApp.Models.DTO
{
    public class MessageDTO
    {
        public Guid Id { get; set; }
        public UserShortDTO Author { get; set; }
        public string Content { get; set; }
    }
    public class CreateMessageDTO
    {
        [Required]
        [MinLength(1)]
        [MaxLength(320)]
        public string Content { get; set; }
    }
    public class EditMessageDTO
    {
        [MinLength(1)]
        [MaxLength(320)]
        public string Content { get; set; }
    }
}
