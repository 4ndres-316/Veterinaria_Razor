using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using gestion_veterinaria.Data;
using gestion_veterinaria.Models;

namespace gestion_veterinaria.Pages
{
    public class CitasModel : PageModel
    {
        private readonly DataStore _store;

        public CitasModel(DataStore store)
        {
            _store = store;
        }

        [BindProperty]
        public Cita Cita { get; set; } = new();

        public SelectList MascotasSelectList { get; set; } = new(new List<object>());
        public SelectList VeterinariosSelectList { get; set; } = new(new List<object>());

        public void OnGet()
        {
            CargarCombos();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                CargarCombos();
                return Page();
            }

            // Si el estado no es Completada, no debería tener diagnóstico guardado
            if (Cita.Estado != EstadoCita.Completada)
            {
                Cita.Diagnostico = string.Empty;
            }

            Cita.Id = _store.SiguienteCitaId();
            _store.Citas.Add(Cita);

            return RedirectToPage("./Index");
        }

        private void CargarCombos()
        {
            var mascotas = _store.Mascotas
                .Where(m => m.Estado == EstadoMascota.Activo)
                .ToList();

            var veterinarios = _store.Veterinarios
                .Where(v => v.Estado == EstadoVeterinario.Activo)
                .ToList();

            MascotasSelectList = new SelectList(mascotas, "Id", "Nombre");
            VeterinariosSelectList = new SelectList(veterinarios, "Id", "Nombre");
        }
    }
}