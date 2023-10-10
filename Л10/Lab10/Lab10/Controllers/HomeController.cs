using Lab10.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab10.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost] public IActionResult Index(QuardaticEquation equation)
    {
        if (!ModelState.IsValid) return View(equation);
        var d = Math.Pow(equation.b, 2) - 4 * equation.a * equation.c; // b^2 - 4ac
        equation.Result = new Result
        {
            D = d
        };

        if (d >= 0)
        {
            var x1 = (-equation.b + Math.Sqrt(d)) / (2 * equation.a);
            var x2 = (-equation.b - Math.Sqrt(d)) / (2 * equation.a);

            equation.Result.X1 = x1;
            equation.Result.X2 = x2;
        }

        return View(equation);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
