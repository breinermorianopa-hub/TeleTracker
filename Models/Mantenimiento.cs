using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeleTracker.Models
{
    [Table("mantenimientos")]
    public class Mantenimiento
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("antena_id")]
        public int AntenaId { get; set; }

        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        [Column("fecha_programada")]
        public DateTime FechaProgramada { get; set; }

        [Column("estado")]
        public string Estado { get; set; } = "PENDIENTE";

        [Column("observaciones")]
        public string? Observaciones { get; set; }

        [ForeignKey("AntenaId")]
        public Antena? Antena { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario? Usuario { get; set; }
    }
}