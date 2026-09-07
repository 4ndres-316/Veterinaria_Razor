using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using gestion_veterinaria.Data;
using gestion_veterinaria.Models;

namespace gestion_veterinaria.Pages
{
    public class PropietariosModel : PageModel
    {
        private readonly VeterinariaContext _context;

        public PropietariosModel(VeterinariaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Propietario Propietario { get; set; } = new();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Propietarios.Add(Propietario);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
