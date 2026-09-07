using System.ComponentModel.DataAnnotations;

namespace gestion_veterinaria.Models
{
    public class Veterinario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        [StringLength(100, ErrorMessage = "Los apellidos no pueden superar los 100 caracteres")]
        public string Apellidos { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "La especialidad no puede superar los 100 caracteres")]
        public string Especialidad { get; set; } = string.Empty;

        [Phone(ErrorMessage = "El teléfono no tiene un formato válido")]
        [StringLength(20, ErrorMessage = "El teléfono no puede superar los 20 caracteres")]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe indicar el estado del veterinario")]
        public EstadoVeterinario Estado { get; set; }
    }
}
