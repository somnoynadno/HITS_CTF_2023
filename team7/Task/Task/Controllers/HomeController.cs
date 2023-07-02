using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Task.Models;
using Task.Results;

namespace Task.Controllers;

public class HomeController : Controller
{
    private readonly ResultsService _resultsService;
    private readonly string[] tasks;
    private readonly bool[] successTasks;

    public HomeController(ResultsService resultsService)
    {
        _resultsService = resultsService;
        tasks = new string[]
        {
            "Расшифруйте 1586 81965 22228 146082 22880 99632 1586 81226 97844 118312 72850 138510 79940 163640 24547 85360 82898 24547 163640 1586 134250 164255 1586 72675 24547 122252 168743 24547 82898 1586 158770 119482 1586 139273 85842 24547 114238 118312 128452 82898 1586 79940 1586 139273 109007 82898 24547 1586 118312 1586 24547 24547 167524 167524 150594 128452 119482 163640 24547 134250 1586 163640 1586 154760 85842 82898 118312 128452 139273 82898 1586 128452 134250 150594 163640 163640 82898 24547 154760 82898 154760 1586 163640 109007 24547 82898 154760 150594 138510 158770 82898 1586 164255 1586 158770 158770 82898 1586 82898 1586 139273 164255 158770 82898 24547 1586 82898 82898 1586 158770 1586 158770 82898 82898 138510 82898 163640 128452 119482 24547 1586 150594 118312 24547 154760 158770 82898 138510 82898 82898 1586 24547, зная e = 65537, n = 182643, d = 14753. Подсказка: RSA"
        };
    }

    public IActionResult Index()
    {
        var viewModel = new ResultViewModel
        {
            Task = tasks[0]
        };
        return View(viewModel);
    }
    
    [HttpPost]
    public IActionResult CheckResult(ResultViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("Index", model);
        }

        if (CheckResult(model.Answer))
        {
            var viewModel = new FinishViewModel
            {
                Flag = _resultsService.GetFlag()
            };
            
            return View("Finish", viewModel);
        }

        model.Task = tasks[0];
        model.Error = "Ответ неверный";

        return View("Index", model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private bool CheckResult(string result)
    {
        var expectedResult = _resultsService.GetResult();
        
        return result == expectedResult;
    }
}