using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using gestion_veterinaria.Data;
using gestion_veterinaria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace gestion_veterinaria.Pages
{
    [Authorize(Roles = $"{SeedData.RolAdmin}, {SeedData.RolVeterinario}")]
    public class IndexModel : PageModel
    {
        private readonly VeterinariaContext _context;

        public IndexModel(VeterinariaContext context)
        {
            _context = context;
        }

        public List<Propietario> Propietarios { get; set; } = new();
        public List<Mascota> Mascotas { get; set; } = new();
        public List<Cita> Citas { get; set; } = new();

        public void OnGet()
        {
            Propietarios = _context.Propietarios.ToList();
            Mascotas = _context.Mascotas.ToList();
            Citas = _context.Citas
                .Include(c => c.Mascota)
                .Include(c => c.Veterinario)
                .ToList();
        }

        public async Task<IActionResult> OnPostCambiarEstadoPropietarioAsync(int id, EstadoPropietario nuevoEstado)
        {
            var propietario = await _context.Propietarios.FindAsync(id);
            if (propietario != null)
            {
                propietario.Estado = nuevoEstado;
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostCambiarEstadoMascotaAsync(int id, EstadoMascota nuevoEstado)
        {
            var mascota = await _context.Mascotas.FindAsync(id);
            if (mascota != null)
            {
                mascota.Estado = nuevoEstado;
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostCambiarEstadoCitaAsync(int id, EstadoCita nuevoEstado)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita != null)
            {
                cita.Estado = nuevoEstado;

                if (nuevoEstado != EstadoCita.Completada)
                {
                    cita.Diagnostico = string.Empty;
                }

                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        public string NombrePropietario(int id) =>
            _context.Propietarios.FirstOrDefault(p => p.Id == id)?.Nombre ?? "—";

        public string NombreMascota(int id) =>
            _context.Mascotas.FirstOrDefault(m => m.Id == id)?.Nombre ?? "—";

        public string NombreVeterinario(int id) =>
            _context.Veterinarios.FirstOrDefault(v => v.Id == id)?.Nombre ?? "—";
    }
}
