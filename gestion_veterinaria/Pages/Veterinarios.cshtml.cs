using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using gestion_veterinaria.Data;
using gestion_veterinaria.Models;

namespace gestion_veterinaria.Pages
{
    public class VeterinariosModel : PageModel
    {
        private readonly DataStore _store;

        public VeterinariosModel(DataStore store)
        {
            _store = store;
        }

        [BindProperty]
        public Veterinario Veterinario { get; set; } = new();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Veterinario.Id = _store.SiguienteVeterinarioId();
            _store.Veterinarios.Add(Veterinario);

            return RedirectToPage("./Index");
        }
    }
}