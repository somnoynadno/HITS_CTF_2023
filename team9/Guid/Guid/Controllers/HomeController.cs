using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Guid.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Guid.Controllers;

public class HomeController : Controller
{
    private readonly Random _random;
    
    private const string Salt =
        "Don't listen to the radio Hear something that ya ready know I got no radio Don't speak upon the telephone Hear somethin' that you're never shownI got no telephone";


    public HomeController(Random random)
    {
        _random = random;
    }

    public IActionResult Index(string guid = "3b1937f4-e652-4b6b-b547-c298d9594ddb")
    {
        if (guid[0] == '4' && guid[14] == '4' && guid[21] == '4' && guid[32] == '5')
        {
            return RedirectToAction("Flag");
        }

        if (guid[14] == '9')
        {
            return RedirectToAction("ScriptDetector");
        }

        var expression = guid[14] == '4' 
            ? $"{_random.Next(0, 10)} * {_random.Next(0, 10)}" 
            : $"{_random.Next(0, 1000)} * {_random.Next(0, 1000)}";

        return View(new IndexModel(CalculateHash(expression), expression, guid, false));
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(string expression, string hash, int result, string guid)
    {
        if (!CheckHash(expression, hash))
        {
            return RedirectToAction("ResetProgress");
        }

        var operands = expression.Split(" ");

        return int.Parse(operands[0]) * int.Parse(operands[2]) == result
            ? Index(GenerateNextGuid(guid))
            : View(new IndexModel(hash, expression, guid, true));
    }

    public IActionResult ResetProgress()
    {
        return View();
    }

    public IActionResult Flag()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private string GenerateNextGuid(string guid)
    {
        var indexes = new List<int> { 32, 21, 14, 0 };

        foreach (var index in indexes)
        {
            if (guid[index] == '9')
            {
                guid = guid.Remove(index, 1).Insert(index, "0");
                continue;
            }

            var newChar = (int.Parse(guid[index].ToString()) + 1).ToString();
            guid = guid.Remove(index, 1).Insert(index, newChar);
            break;
        }

        return guid;
    }

    private string CalculateHash(string input)
    {
        var bytes = Encoding.Unicode.GetBytes(input + Salt);
        return Encoding.Unicode.GetString(SHA256.Create().ComputeHash(bytes));
    }

    private bool CheckHash(string input, string hash)
    {
        return CalculateHash(input) == hash;
    }

    public IActionResult ScriptDetector()
    {
        return View();
    }
}