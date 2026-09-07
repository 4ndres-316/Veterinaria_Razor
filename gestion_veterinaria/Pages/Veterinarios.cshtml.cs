using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using gestion_veterinaria.Data;
using gestion_veterinaria.Models;

namespace gestion_veterinaria.Pages
{
    public class VeterinariosModel : PageModel
    {
        private readonly VeterinariaContext _context;

        public VeterinariosModel(VeterinariaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Veterinario Veterinario { get; set; } = new();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Veterinarios.Add(Veterinario);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
