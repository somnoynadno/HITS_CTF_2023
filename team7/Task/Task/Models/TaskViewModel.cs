using System.ComponentModel.DataAnnotations;

namespace Task.Models;

public class TaskViewModel
{
    [Required]
    public string Task;
    
    public string? Result;

    public string? Error;
}