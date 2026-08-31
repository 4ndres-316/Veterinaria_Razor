using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace gestion_veterinaria.Models
{
    public class Mascota
    {
        public int Id { get; set; }

        [Required]
        public int PropietarioId { get; set; }

        [ValidateNever]
        public Propietario Propietario { get; set; } = null!;

        [Required]
        public string Nombre { get; set; } = string.Empty;

        public string Especie { get; set; } = string.Empty;
        public string Raza { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        public EstadoMascota Estado { get; set; }
    }
}