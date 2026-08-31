using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using gestion_veterinaria.Data;
using gestion_veterinaria.Models;

namespace gestion_veterinaria.Pages
{
    public class PropietariosModel : PageModel
    {
        private readonly DataStore _store;

        public PropietariosModel(DataStore store)
        {
            _store = store;
        }

        [BindProperty]
        public Propietario Propietario { get; set; } = new();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Propietario.Id = _store.SiguientePropietarioId();
            _store.Propietarios.Add(Propietario);

            return RedirectToPage("./Index");
        }
    }
}