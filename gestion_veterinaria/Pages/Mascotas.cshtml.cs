using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using gestion_veterinaria.Data;
using gestion_veterinaria.Models;
using Microsoft.EntityFrameworkCore;

namespace gestion_veterinaria.Pages
{
    public class MascotasModel : PageModel
    {
        private readonly VeterinariaContext _context;

        public MascotasModel(VeterinariaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mascota Mascota { get; set; } = new();

        public SelectList PropietariosSelectList { get; set; } = new(new List<object>());

        public void OnGet()
        {
            CargarPropietarios();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                CargarPropietarios();
                return Page();
            }

            _context.Mascotas.Add(Mascota);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private void CargarPropietarios()
        {
            var propietarios = _context.Propietarios
                .Where(p => p.Estado == EstadoPropietario.Activo)
                .ToList();

            PropietariosSelectList = new SelectList(propietarios, "Id", "Nombre");
        }
    }
}
