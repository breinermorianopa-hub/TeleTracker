using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeleTracker.Models
{
    [Table("fallos")]
    public class Fallo
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("antena_id")]
        public int AntenaId { get; set; }

        [Required]
        [Column("descripcion")]
        public string Descripcion { get; set; } = null!;

        [Column("prioridad")]
        public string Prioridad { get; set; } = "MEDIA";

        [Column("estado")]
        public string Estado { get; set; } = "REPORTADO";

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("AntenaId")]
        public Antena? Antena { get; set; }
    }
}