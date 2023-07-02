using System.ComponentModel.DataAnnotations;

namespace Task.Models;

public class ResultViewModel
{
    [Required]
    public string Task;
    
    [Required(ErrorMessage = "Необходимо ввести ответ")]
    public string Answer { get; set; }
    
    public string? Error { get; set; }
}