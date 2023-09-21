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
    public class VentasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.venta.Include(v => v.Cliente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.venta == null)
            {
                return NotFound();
            }

            var venta = await _context.venta
                .Include(v => v.Cliente)
                .FirstOrDefaultAsync(m => m.Id_Venta == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            ViewData["id_Cliente"] = new SelectList(_context.Cliente, "Id", "Id");
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Venta,fecha,total,id_Cliente")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_Cliente"] = new SelectList(_context.Cliente, "Id", "Id", venta.id_Cliente);
            return View(venta);
        }

        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.venta == null)
            {
                return NotFound();
            }

            var venta = await _context.venta.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            ViewData["id_Cliente"] = new SelectList(_context.Cliente, "Id", "Id", venta.id_Cliente);
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Venta,fecha,total,id_Cliente")] Venta venta)
        {
            if (id != venta.Id_Venta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaExists(venta.Id_Venta))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_Cliente"] = new SelectList(_context.Cliente, "Id", "Id", venta.id_Cliente);
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.venta == null)
            {
                return NotFound();
            }

            var venta = await _context.venta
                .Include(v => v.Cliente)
                .FirstOrDefaultAsync(m => m.Id_Venta == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.venta == null)
            {
                return Problem("Entity set 'ApplicationDbContext.venta'  is null.");
            }
            var venta = await _context.venta.FindAsync(id);
            if (venta != null)
            {
                _context.venta.Remove(venta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaExists(int id)
        {
          return _context.venta.Any(e => e.Id_Venta == id);
        }
    }
}
