using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccesoController : Controller
    {
        private readonly DA_Usuario _da_usuario;

        public AccesoController(ApplicationDbContext context)
        {
            _da_usuario = new DA_Usuario(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Usuario _usuario)
        {
            var usuario = _da_usuario.ValidarUsuario(_usuario.Correo, _usuario.Clave);

            if (usuario != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Nombre),
                    new Claim("Correo", usuario.Correo),
                };

                // Asignar permisos en función del Id_Rol
                if (usuario.Id_Rol == 1) // 1 para Administrador
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Administrador"));
                    // Otros permisos de administrador
                }
                else if (usuario.Id_Rol == 2) // 2 para Cliente
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Cliente"));
                    // Otros permisos de cliente
                }

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Registrar()
        {
            return View();
        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}
