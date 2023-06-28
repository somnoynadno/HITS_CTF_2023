using BoardApp.Models.ViewModels;
using FeastHub.Common.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace BoardApp
{
    public static class ControllerExtensions
    {
        public static RedirectToActionResult ToError(this ControllerBase controller, Exception exception)
        {
            return controller.RedirectToAction("Fail", "Error", OperationResultViewModel.GenerateFromResult(OperationResultUtilities.DefaultEvaluator(exception)));
        }

        public static ViewResult ReturnWithError(this Controller controller, Exception exception, object? model = null)
        {
            controller.ModelState.AddModelError("Errors", exception!.Message);
            return controller.View(model);
        }
        public static ViewResult ToView(this Controller controller, object model)
        {
            return controller.View(model);
        }
    }
}
