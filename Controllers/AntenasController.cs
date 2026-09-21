using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeleTracker.Data;
using TeleTracker.Models;

namespace TeleTracker.Controllers
{
    [Authorize]
    public class AntenasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AntenasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Antenas (Accesible por Admin, Técnico y Usuario)
        public async Task<IActionResult> Index()
        {
            var antenas = await _context.Antenas
                .OrderByDescending(a => a.CreatedAt)
                .ToListAsync();
            return View(antenas);
        }

        // GET: /Antenas/Crear (Solo Administrador)
        [Authorize(Roles = "1")]
        public IActionResult Crear()
        {
            return View();
        }

        // POST: /Antenas/Crear (Solo Administrador)
        [HttpPost]
        [Authorize(Roles = "1")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Antena antena)
        {
            if (ModelState.IsValid)
            {
                var existeCodigo = await _context.Antenas.AnyAsync(a => a.Codigo == antena.Codigo);
                if (existeCodigo)
                {
                    ModelState.AddModelError("Codigo", "El código de estación ya se encuentra registrado.");
                    return View(antena);
                }

                antena.CreatedAt = DateTime.UtcNow;
                _context.Antenas.Add(antena);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(antena);
        }
    }
}
