using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeleTracker.Models
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("rol_id")]
        public int RolId { get; set; } = 2; // Usa el rol id=2 por defecto

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; } = null!;

        [Required]
        [Column("apellido")]
        public string Apellido { get; set; } = null!;

        [Required]
        [Column("email")]
        public string Email { get; set; } = null!;

        [Required]
        [Column("password_hash")]
        public string PasswordHash { get; set; } = null!;

        [Column("foto_perfil")]
        public string? FotoPerfil { get; set; }

        [Column("email_verificado")]
        public bool EmailVerificado { get; set; } = false;

        [Column("estado")]
        public string Estado { get; set; } = "PENDIENTE_VERIFICACION";

        [Column("intentos_fallidos")]
        public int IntentosFallidos { get; set; } = 0;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}