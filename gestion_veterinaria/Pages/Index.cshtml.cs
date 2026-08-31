using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using gestion_veterinaria.Data;
using gestion_veterinaria.Models;

namespace gestion_veterinaria.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DataStore _store;

        public IndexModel(DataStore store)
        {
            _store = store;
        }

        public List<Propietario> Propietarios => _store.Propietarios;
        public List<Mascota> Mascotas => _store.Mascotas;
        public List<Cita> Citas => _store.Citas;

        public void OnGet()
        {
        }

        public IActionResult OnPostCambiarEstadoPropietario(int id, EstadoPropietario nuevoEstado)
        {
            var propietario = _store.Propietarios.FirstOrDefault(p => p.Id == id);
            if (propietario != null)
            {
                propietario.Estado = nuevoEstado;
            }
            return RedirectToPage();
        }

        public IActionResult OnPostCambiarEstadoMascota(int id, EstadoMascota nuevoEstado)
        {
            var mascota = _store.Mascotas.FirstOrDefault(m => m.Id == id);
            if (mascota != null)
            {
                mascota.Estado = nuevoEstado;
            }
            return RedirectToPage();
        }

        public IActionResult OnPostCambiarEstadoCita(int id, EstadoCita nuevoEstado)
        {
            var cita = _store.Citas.FirstOrDefault(c => c.Id == id);
            if (cita != null)
            {
                cita.Estado = nuevoEstado;

                if (nuevoEstado != EstadoCita.Completada)
                {
                    cita.Diagnostico = string.Empty;
                }
            }
            return RedirectToPage();
        }

        public string NombrePropietario(int id) =>
            _store.Propietarios.FirstOrDefault(p => p.Id == id)?.Nombre ?? "—";

        public string NombreMascota(int id) =>
            _store.Mascotas.FirstOrDefault(m => m.Id == id)?.Nombre ?? "—";

        public string NombreVeterinario(int id) =>
            _store.Veterinarios.FirstOrDefault(v => v.Id == id)?.Nombre ?? "—";
    }
}