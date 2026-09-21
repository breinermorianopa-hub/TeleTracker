using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeleTracker.Data;
using TeleTracker.Models;

namespace TeleTracker.Controllers
{
    public class MantenimientosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MantenimientosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mantenimientos
        public async Task<IActionResult> Index(string estado)
        {
            var query = _context.Mantenimientos
                .Include(m => m.Antena)
                .Include(m => m.Usuario)
                .AsQueryable();

            if (!string.IsNullOrEmpty(estado))
            {
                query = query.Where(m => m.Estado == estado);
            }

            var mantenimientos = await query.OrderByDescending(m => m.FechaProgramada).ToListAsync();
            ViewBag.EstadoActual = estado;
            return View(mantenimientos);
        }

        // GET: Mantenimientos/Crear
        public async Task<IActionResult> Crear()
        {
            ViewBag.Antenas = new SelectList(await _context.Antenas.ToListAsync(), "Id", "Nombre");
            
            var tecnicos = await _context.Usuarios
                .Where(u => u.RolId == 2)
                .Select(u => new { u.Id, NombreCompleto = u.Nombre + " " + u.Apellido })
                .ToListAsync();

            ViewBag.Tecnicos = new SelectList(tecnicos, "Id", "NombreCompleto");
            return View();
        }

        // POST: Mantenimientos/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Mantenimiento mantenimiento)
        {
            if (ModelState.IsValid)
            {
                mantenimiento.Estado = "Pendiente";
                _context.Add(mantenimiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Antenas = new SelectList(await _context.Antenas.ToListAsync(), "Id", "Nombre", mantenimiento.IdAntena);
            
            var tecnicos = await _context.Usuarios
                .Where(u => u.RolId == 2)
                .Select(u => new { u.Id, NombreCompleto = u.Nombre + " " + u.Apellido })
                .ToListAsync();
                
            ViewBag.Tecnicos = new SelectList(tecnicos, "Id", "NombreCompleto", mantenimiento.IdUsuario);
            
            return View(mantenimiento);
        }

        // POST: Mantenimientos/CambiarEstado
        [HttpPost]
        public async Task<IActionResult> CambiarEstado(int id, string nuevoEstado)
        {
            var mantenimiento = await _context.Mantenimientos.FindAsync(id);
            if (mantenimiento == null)
            {
                return NotFound();
            }

            mantenimiento.Estado = nuevoEstado;
            _context.Update(mantenimiento);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}