using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace gestion_veterinaria.Models
{
    public class Cita
    {
        public int Id { get; set; }

        [Required]
        public int MascotaId { get; set; }

        [ValidateNever]
        public Mascota Mascota { get; set; } = null!;

        [Required]
        public int VeterinarioId { get; set; }

        [ValidateNever]
        public Veterinario Veterinario { get; set; } = null!;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FechaHoraAtencion { get; set; }

        public string Motivo { get; set; } = string.Empty;

        public EstadoCita Estado { get; set; }

        public string Diagnostico { get; set; } = string.Empty;
    }
}