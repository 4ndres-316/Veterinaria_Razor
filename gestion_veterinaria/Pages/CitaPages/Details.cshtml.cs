using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using gestion_veterinaria.Models;
using gestion_veterinaria.Data;
using Microsoft.AspNetCore.Authorization;

namespace gestion_veterinaria.Pages.CitaPages;

[Authorize(Roles = $"{SeedData.RolAdmin}, {SeedData.RolVeterinario}, {SeedData.RolCliente}")]
public class DetailsModel : PageModel
{
    private readonly VeterinariaContext _context;
    public DetailsModel(VeterinariaContext context)
    {
        _context = context;
    }

    public Cita Cita { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var cita = await _context.Citas.Include(m => m.Mascota).Include(m => m.Veterinario).FirstOrDefaultAsync(m => m.Id == id);
        if (cita is null)
        {
            return NotFound();
        }
        else
        {
            Cita = cita;
        }

        return Page();
    }
}
