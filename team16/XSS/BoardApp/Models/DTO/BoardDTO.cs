using System.ComponentModel.DataAnnotations;

namespace BoardApp.Models.DTO
{
    public class BoardDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<MessageDTO> Messages { get; set; } = new();

        public List<UserShortDTO> Members { get; set; }
        public UserShortDTO Creator { get; set; }

        public bool IsPrivate { get; set; } = default;

    }
    public class CreateBoardDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; } = "Nameless Board";

        [Required]
        public bool IsPrivate { get; set; } = default;
    }
    public class EditBoardDTO
    {
        [MinLength(3)]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        public bool IsPrivate { get; set; }
    }

    public class BoardShortDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CreatorId { get; set; }

        public bool IsPrivate { get; set; } = default;
    }
}
