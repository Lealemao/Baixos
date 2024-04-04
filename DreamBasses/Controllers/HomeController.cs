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
        List<Marca> marcas = [];
        using (StreamReader leitor = new("Data\\marcas.json"))
        {
            string dados = leitor.ReadToEnd();
            marcas = JsonSerializer.Deserialize<List<Marca>>(dados);
        }
        ViewData["Marcas"] = marcas;
        return View(baixos);
    }
    public IActionResult Details(int id)
    {
        List<Baixo> baixos = [];
        using (StreamReader leitor = new("Data\\baixos.json"))
        {
            string dados = leitor.ReadToEnd();
            baixos = JsonSerializer.Deserialize<List<Baixo>>(dados);
        }
        List<Marca> marcas = [];
        using (StreamReader leitor = new("Data\\marcas.json"))
        {
            string dados = leitor.ReadToEnd();
            marcas = JsonSerializer.Deserialize<List<Marca>>(dados);
        }
        DetailsVM details = new() {
            Basses = baixos,
            Atual = baixos.FirstOrDefault(b => b.Num == id),
            Anterior = baixos.OrderByDescending(b => b.Num).FirstOrDefault(b => b.Num < id),    
            Proximo = baixos.OrderBy(b => b.Num).FirstOrDefault(b => b.Num > id)
        };
        return View(details);
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
