using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace gestion_veterinaria.Models
{
    public class Mascota
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El propietario es obligatorio")]
        [Display(Name = "Propietario")]
        public int PropietarioId { get; set; }

        [ValidateNever]
        public Propietario Propietario { get; set; } = null!;

        [Required(ErrorMessage = "El nombre de la mascota es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe indicar la especie")]
        [StringLength(50, ErrorMessage = "La especie no puede superar los 50 caracteres")]
        [Display(Name = "Especie")]
        public string Especie { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "La raza no puede superar los 50 caracteres")]
        [Display(Name = "Raza")]
        public string Raza { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date)]
        [PastDate(ErrorMessage = "La fecha de nacimiento debe estar en el pasado")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Debe indicar el estado de la mascota")]
        [Display(Name = "Estado")]
        public EstadoMascota Estado { get; set; }
    }

    // Validación personalizada
    public class PastDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateTime fecha)
            {
                return fecha <= DateTime.Now;
            }
            return false;
        }
    }
}
