using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeleTracker.Models
{
    [Table("notificaciones")]
    public class Notificacion
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        [Required]
        [Column("mensaje")]
        public string Mensaje { get; set; } = null!;

        [Column("leido")]
        public bool Leido { get; set; } = false;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("UsuarioId")]
        public Usuario? Usuario { get; set; }
    }
}