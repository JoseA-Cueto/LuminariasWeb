using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LuminariasWeb.sln.Models;

namespace LuminariasWeb.sln.Controllers;

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

    public IActionResult Privacy()
    {
        return View();
    }
    //codigo de pruebas de fetch, no tiene que ver con la app
    [HttpGet]
    public  IActionResult GetLamps(){
        var Lamps =  new List<object>{
            new {Id = 1, Name = "Lamp1", Description = "Description1"},
            new {Id = 3, Name = "Lamp3", Description = "Description3"},
            new {Id = 2, Name = "Lamp2", Description = "Description2"}
        };
        return Ok(Lamps);
    }

    
}
