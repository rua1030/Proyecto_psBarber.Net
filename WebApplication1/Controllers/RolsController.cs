using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class RolsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RolsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rols
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rol.ToListAsync());
        }

    }
}