using Microsoft.EntityFrameworkCore;
using TeleTracker.Models;

namespace TeleTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Antena> Antenas { get; set; } = null!;
        public DbSet<Fallo> Fallos { get; set; } = null!;
        public DbSet<Mantenimiento> Mantenimientos { get; set; } = null!;
        public DbSet<Notificacion> Notificaciones { get; set; } = null!;
        public DbSet<Reporte> Reportes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Habilitar compatibilidad con timestamps/fechas en PostgreSQL
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
    }
}