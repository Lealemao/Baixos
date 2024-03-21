using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DreamBasses.Models;
using System.Text.Json;

namespace DreamBasses.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Baixo> baixos = [];
        using (StreamReader leitor = new("Data\\baixos.json"))
        {
            string dados = leitor.ReadToEnd();
            baixos = JsonSerializer.Deserialize<List<Baixo>>(dados);
        }
        return View(baixos);
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
