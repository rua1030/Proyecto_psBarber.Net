using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

//1.- AÑADIR LA AUTHORIZACION
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    [Authorize]
    //2.- AÑADIR LA AUTHORIZACION
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize(Roles = "Administrador,Cliente,Empleado")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrador,Empleado")]
        public IActionResult Ventas()
        {
            return View();
        }

        [Authorize(Roles = "Administrador,Supervisor")]
        public IActionResult Compras()
        {
            return View();
        }

        [Authorize(Roles = "Administrador,Empleado")]
        public IActionResult Clientes()
        {
            return View();
        }

        [AllowAnonymous]
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
}