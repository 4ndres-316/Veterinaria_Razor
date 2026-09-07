using System.ComponentModel.DataAnnotations;

namespace gestion_veterinaria.Models
{
    public class Propietario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(100, ErrorMessage = "El apellido no puede superar los 100 caracteres")]
        public string Apellido { get; set; } = string.Empty;

        [Phone(ErrorMessage = "El teléfono no tiene un formato válido")]
        [StringLength(20, ErrorMessage = "El teléfono no puede superar los 20 caracteres")]
        public string Telefono { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "El correo electrónico no tiene un formato válido")]
        [StringLength(150, ErrorMessage = "El correo electrónico no puede superar los 150 caracteres")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe indicar el estado del propietario")]
        public EstadoPropietario Estado { get; set; }
    }
}
