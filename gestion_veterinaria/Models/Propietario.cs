using System.ComponentModel.DataAnnotations;

namespace gestion_veterinaria.Models
{
    public class Propietario
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Phone]
        public string Telefono { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public EstadoPropietario Estado { get; set; }
    }
}