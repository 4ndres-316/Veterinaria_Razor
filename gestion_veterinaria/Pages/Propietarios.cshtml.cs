using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace gestion_veterinaria.Pages
{
    public class PropietariosModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public PropietariosModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Propietario Propietario { get; set; }

        // Muestra el formulario vacío
        public void OnGet()
        {
        }

        // Recibe los datos del formulario y los guarda
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Propietarios.Add(Propietario);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index"); // o donde quieras redirigir
        }
    }
}
