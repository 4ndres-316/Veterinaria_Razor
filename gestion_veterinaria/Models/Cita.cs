using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace gestion_veterinaria.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

    public class Cita
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La mascota es obligatoria")]
        public int MascotaId { get; set; }

        [ValidateNever]
        public Mascota Mascota { get; set; } = null!;

        [Required(ErrorMessage = "El veterinario es obligatorio")]
        public int VeterinarioId { get; set; }

        [ValidateNever]
        public Veterinario Veterinario { get; set; } = null!;

        [Required(ErrorMessage = "Debe indicar fecha y hora de atención")]
        [DataType(DataType.DateTime)]
        [FutureDate(ErrorMessage = "La cita debe ser en el futuro")]
        public DateTime FechaHoraAtencion { get; set; }

        [Required(ErrorMessage = "Debe indicar el motivo de la cita")]
        [StringLength(200, ErrorMessage = "El motivo no puede superar los 200 caracteres")]
        public string Motivo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe indicar el estado de la cita")]
        public EstadoCita Estado { get; set; }

        [StringLength(500, ErrorMessage = "El diagnóstico no puede superar los 500 caracteres")]
        public string Diagnostico { get; set; } = string.Empty;
    }

    // Validación personalizada
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateTime fecha)
            {
                return fecha > DateTime.Now;
            }
            return false;
        }
    }

}