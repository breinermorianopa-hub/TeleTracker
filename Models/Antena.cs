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

        [Required(ErrorMessage = "El código de la estación es obligatorio.")]
        [StringLength(20, ErrorMessage = "El código no puede superar los 20 caracteres.")]
        [Column("codigo")]
        public string Codigo { get; set; } = null!;

        [Required(ErrorMessage = "El nombre de la antena es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        [Column("nombre")]
        public string Nombre { get; set; } = null!;

        [StringLength(255)]
        [Column("ubicacion")]
        public string? Ubicacion { get; set; }

        // --- Geolocalización (Crucial para SIG / Mapas Interactivos) ---
        [Required(ErrorMessage = "La latitud es obligatoria.")]
        [Column("latitud")]
        public double Latitud { get; set; }

        [Required(ErrorMessage = "La longitud es obligatoria.")]
        [Column("longitud")]
        public double Longitud { get; set; }

        [Column("altura_torre_m")]
        public double? AlturaTorreM { get; set; } // Altura en metros sobre el nivel del suelo

        [Column("radio_cobertura_km")]
        public double? RadioCoberturaKm { get; set; } // Cobertura estimada

        // --- Especificaciones Técnicas de Telecomunicaciones ---
        [Required(ErrorMessage = "La tecnología de red es obligatoria.")]
        [StringLength(20)]
        [Column("tecnologia")]
        public string Tecnologia { get; set; } = "4G LTE"; // Ejemplo: 3G, 4G LTE, 5G, Microondas

        [Column("frecuencia_mhz")]
        public double? FrecuenciaMhz { get; set; } // Banda de operación (Ej: 1800, 2600)

        [Required(ErrorMessage = "El estado operativo es obligatorio.")]
        [StringLength(30)]
        [Column("estado")]
        public string Estado { get; set; } = "OPERATIVA"; // OPERATIVA, MANTENIMIENTO, INACTIVA

        // --- Auditoría y Trazabilidad de Datos ---
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
