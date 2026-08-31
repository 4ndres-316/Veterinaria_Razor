using System.ComponentModel.DataAnnotations;

namespace gestion_veterinaria.Models
{
    public class Veterinario
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Apellidos { get; set; } = string.Empty;

        public string Especialidad { get; set; } = string.Empty;

        [Phone]
        public string Telefono { get; set; } = string.Empty;

        public EstadoVeterinario Estado { get; set; }
    }
}