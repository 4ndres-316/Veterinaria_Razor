using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace gestion_veterinaria.Pages
{
    public class MascotasModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public MascotasModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mascota Mascota { get; set; }

        public SelectList PropietariosSelectList { get; set; }

        public async Task OnGetAsync()
        {
            await CargarPropietariosAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await CargarPropietariosAsync();
                return Page();
            }

            _context.Mascotas.Add(Mascota);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private async Task CargarPropietariosAsync()
        {
            var propietarios = await _context.Propietarios
                .Where(p => p.Estado == EstadoPropietario.Activo)
                .ToListAsync();

            PropietariosSelectList = new SelectList(propietarios, "Id", "Nombre");
        }
    }
}
