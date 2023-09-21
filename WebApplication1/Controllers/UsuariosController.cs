using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;


namespace WebApplication1.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Clave,Correo,Id_Rol")] Usuario usuario)
        {
           if (ModelState.IsValid)
    {
        // Verificar si el correo electrónico ya existe en la base de datos
        var existingUser = await _context.Usuario.FirstOrDefaultAsync(u => u.Correo == usuario.Correo);
        
        if (existingUser != null)
        {
            // Si el correo ya existe, muestra un mensaje de error
            ModelState.AddModelError("Correo", "El correo electrónico ya está registrado.");
            return View(usuario);
        }

        usuario.Id_Rol = 2;
        _context.Add(usuario);
        await _context.SaveChangesAsync();

        // Establece un mensaje de éxito en TempData
        TempData["SuccessMessage"] = "Registro exitoso. ¡Bienvenido!";

        //return RedirectToAction("Index", "Acceso"); // Redirige a la acción "Index" del controlador "Acceso"
    }
    return View(usuario);
        }
    }
}

