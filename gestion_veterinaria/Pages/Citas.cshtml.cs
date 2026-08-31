using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace gestion_veterinaria.Pages
{
    public class CitasModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CitasModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cita Cita { get; set; }

        public SelectList MascotasSelectList { get; set; }
        public SelectList VeterinariosSelectList { get; set; }

        public async Task OnGetAsync()
        {
            await CargarCombosAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await CargarCombosAsync();
                return Page();
            }

            _context.Citas.Add(Cita);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private async Task CargarCombosAsync()
        {
            var mascotas = await _context.Mascotas
                .Where(m => m.Estado == EstadoMascota.Activo)
                .ToListAsync();

            var veterinarios = await _context.Veterinarios
                .Where(v => v.Estado == EstadoVeterinario.Activo)
                .ToListAsync();

            MascotasSelectList = new SelectList(mascotas, "Id", "Nombre");
            VeterinariosSelectList = new SelectList(veterinarios, "Id", "Nombre");
        }
    }
}
