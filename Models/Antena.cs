using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeleTracker.Models
{
    [Table("antenas")]
    public class Antena
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("codigo")]
        public string Codigo { get; set; } = null!;

        [Required]
        [Column("nombre")]
        public string Nombre { get; set; } = null!;

        [Column("ubicacion")]
        public string? Ubicacion { get; set; }

        [Column("latitud")]
        public double Latitud { get; set; }

        [Column("longitud")]
        public double Longitud { get; set; }

        [Column("estado")]
        public string Estado { get; set; } = "OPERATIVA";
    }
}