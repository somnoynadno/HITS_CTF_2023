using BoardApp.Models;
using BoardApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BoardApp.Controllers
{
    public class ErrorController : Controller
    {
        public ErrorController() { }

        public IActionResult Fail(OperationResultViewModel result)
        {
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}