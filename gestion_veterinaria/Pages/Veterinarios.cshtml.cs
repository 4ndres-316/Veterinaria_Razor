using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace gestion_veterinaria.Pages
{
    public class VeterinariosModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public VeterinariosModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Veterinario Veterinario { get; set; }

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
