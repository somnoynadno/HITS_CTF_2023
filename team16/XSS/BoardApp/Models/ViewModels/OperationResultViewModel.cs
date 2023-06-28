using Microsoft.AspNetCore.Mvc;

namespace BoardApp.Models.ViewModels
{
    public class OperationResultViewModel
    {
        public string? Message { get; set; }
        public int Status { get; set; }

        public static OperationResultViewModel GenerateFromResult(ObjectResult result)
        {
            return new OperationResultViewModel
            {
                Message = result.Value?.ToString(),
                Status = result.StatusCode ?? 500
            };
        }
    }
}