using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeleTracker.Models
{
    [Table("reportes")]
    public class Reporte
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("titulo")]
        public string Titulo { get; set; } = null!;

        [Column("contenido")]
        public string? Contenido { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}