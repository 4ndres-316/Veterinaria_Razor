using System.ComponentModel.DataAnnotations;

namespace gestion_veterinaria.Models
{
    public enum EstadoPropietario
    {
        Activo,
        Inactivo
    }

    public enum EstadoMascota
    {
        Activo,
        Inactivo
    }

    public enum EstadoVeterinario
    {
        Activo,
        Inactivo
    }

    public enum EstadoCita
    {
        [Display(Name = "Pendiente")]
        Pendiente,
        [Display(Name = "Completada")]
        Completada,
        [Display(Name = "Cancelada")]
        Cancelada
    }
}