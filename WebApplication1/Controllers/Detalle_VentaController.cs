using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Detalle_VentaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Detalle_VentaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Detalle_Venta
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Detalle_Venta.Include(d => d.Venta);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Detalle_Venta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Detalle_Venta == null)
            {
                return NotFound();
            }

            var detalle_Venta = await _context.Detalle_Venta
                .Include(d => d.Venta)
                .FirstOrDefaultAsync(m => m.id_Detalle_Venta == id);
            if (detalle_Venta == null)
            {
                return NotFound();
            }

            return View(detalle_Venta);
        }

        // GET: Detalle_Venta/Create
        public IActionResult Create()
        {
            ViewData["id_Venta"] = new SelectList(_context.venta, "Id_Venta", "Id_Venta");
            return View();
        }

        // POST: Detalle_Venta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_Detalle_Venta,subtotal,id_Servicio,id_Venta")] Detalle_Venta detalle_Venta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalle_Venta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_Venta"] = new SelectList(_context.venta, "Id_Venta", "Id_Venta", detalle_Venta.id_Venta);
            return View(detalle_Venta);
        }

        // GET: Detalle_Venta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Detalle_Venta == null)
            {
                return NotFound();
            }

            var detalle_Venta = await _context.Detalle_Venta.FindAsync(id);
            if (detalle_Venta == null)
            {
                return NotFound();
            }
            ViewData["id_Venta"] = new SelectList(_context.venta, "Id_Venta", "Id_Venta", detalle_Venta.id_Venta);
            return View(detalle_Venta);
        }

        // POST: Detalle_Venta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_Detalle_Venta,subtotal,id_Servicio,id_Venta")] Detalle_Venta detalle_Venta)
        {
            if (id != detalle_Venta.id_Detalle_Venta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalle_Venta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Detalle_VentaExists(detalle_Venta.id_Detalle_Venta))
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
            ViewData["id_Venta"] = new SelectList(_context.venta, "Id_Venta", "Id_Venta", detalle_Venta.id_Venta);
            return View(detalle_Venta);
        }

        // GET: Detalle_Venta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Detalle_Venta == null)
            {
                return NotFound();
            }

            var detalle_Venta = await _context.Detalle_Venta
                .Include(d => d.Venta)
                .FirstOrDefaultAsync(m => m.id_Detalle_Venta == id);
            if (detalle_Venta == null)
            {
                return NotFound();
            }

            return View(detalle_Venta);
        }

        // POST: Detalle_Venta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Detalle_Venta == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Detalle_Venta'  is null.");
            }
            var detalle_Venta = await _context.Detalle_Venta.FindAsync(id);
            if (detalle_Venta != null)
            {
                _context.Detalle_Venta.Remove(detalle_Venta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Detalle_VentaExists(int id)
        {
          return _context.Detalle_Venta.Any(e => e.id_Detalle_Venta == id);
        }
    }
}
