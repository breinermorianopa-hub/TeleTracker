using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeleTracker.Data;
using TeleTracker.Models;

namespace TeleTracker.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Usuarios/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Usuarios/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Por favor ingrese el correo y la contraseña.";
                return View();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == password);

            if (usuario == null)
            {
                ViewBag.Error = "Correo o contraseña incorrectos.";
                return View();
            }

            // Redirigir al inicio/dashboard tras iniciar sesión
            return RedirectToAction("Index", "Home");
        }

        // GET: /Usuarios/Registro
        public IActionResult Registro()
        {
            return View();
        }

        // POST: /Usuarios/Registro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var existe = await _context.Usuarios.AnyAsync(u => u.Email == usuario.Email);
                if (existe)
                {
                    ViewBag.Error = "El correo ya se encuentra registrado.";
                    return View(usuario);
                }

                usuario.CreatedAt = DateTime.UtcNow;
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return RedirectToAction("Login");
            }

            return View(usuario);
        }
    }
}