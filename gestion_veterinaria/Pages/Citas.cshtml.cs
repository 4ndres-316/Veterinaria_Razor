using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using gestion_veterinaria.Data;
using gestion_veterinaria.Models;
using Microsoft.EntityFrameworkCore;

namespace gestion_veterinaria.Pages
{
    public class CitasModel : PageModel
    {
        private readonly VeterinariaContext _context;

        public CitasModel(VeterinariaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cita Cita { get; set; } = new();

        public SelectList MascotasSelectList { get; set; } = new(new List<object>());
        public SelectList VeterinariosSelectList { get; set; } = new(new List<object>());

        public void OnGet()
        {
            CargarCombos();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                CargarCombos();
                return Page();
            }

            // Si cita no completada, no guarda diagnóstico
            if (Cita.Estado != EstadoCita.Completada)
            {
                Cita.Diagnostico = string.Empty;
            }

            _context.Citas.Add(Cita);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private void CargarCombos()
        {
            var mascotas = _context.Mascotas
                .Where(m => m.Estado == EstadoMascota.Activo)
                .ToList();

            var veterinarios = _context.Veterinarios
                .Where(v => v.Estado == EstadoVeterinario.Activo)
                .ToList();

            MascotasSelectList = new SelectList(mascotas, "Id", "Nombre");
            VeterinariosSelectList = new SelectList(veterinarios, "Id", "Nombre");
        }
    }
}
