using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using gestion_veterinaria.Data;
using gestion_veterinaria.Models;

namespace gestion_veterinaria.Pages
{
    public class MascotasModel : PageModel
    {
        private readonly DataStore _store;

        public MascotasModel(DataStore store)
        {
            _store = store;
        }

        [BindProperty]
        public Mascota Mascota { get; set; } = new();

        public SelectList PropietariosSelectList { get; set; } = new(new List<object>());

        public void OnGet()
        {
            CargarPropietarios();
        }

        public IActionResult OnPost()
        {
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }
            if (!ModelState.IsValid)
            {
                CargarPropietarios();
                return Page();
            }

            Mascota.Id = _store.SiguienteMascotaId();
            _store.Mascotas.Add(Mascota);

            return RedirectToPage("./Index");
        }

        private void CargarPropietarios()
        {
            var propietarios = _store.Propietarios
                .Where(p => p.Estado == EstadoPropietario.Activo)
                .ToList();

            PropietariosSelectList = new SelectList(propietarios, "Id", "Nombre");
        }
    }
}