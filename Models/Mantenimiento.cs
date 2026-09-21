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
        public int IdAntena { get; set; }

        [ForeignKey("IdAntena")]
        public Antena? Antena { get; set; }

        [Column("usuario_id")]
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }

        [Column("tipo")]
        public string Tipo { get; set; } = string.Empty;

        [Column("fecha_programada")]
        public DateTime FechaProgramada { get; set; }

        [Column("descripcion")]
        public string? Descripcion { get; set; }

        [Column("estado")]
        public string Estado { get; set; } = "Pendiente";
    }
}