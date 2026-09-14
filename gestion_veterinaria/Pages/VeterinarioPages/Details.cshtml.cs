using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using gestion_veterinaria.Models;
using gestion_veterinaria.Data;
using Microsoft.AspNetCore.Authorization;

namespace gestion_veterinaria.Pages.VeterinarioPages;

[Authorize(Roles = $"{SeedData.RolAdmin}, {SeedData.RolVeterinario}")]
public class DetailsModel : PageModel
{
    private readonly VeterinariaContext _context;
    public DetailsModel(VeterinariaContext context)
    {
        _context = context;
    }

    public Veterinario Veterinario { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var veterinario = await _context.Veterinarios.FirstOrDefaultAsync(m => m.Id == id);
        if (veterinario is null)
        {
            return NotFound();
        }
        else
        {
            Veterinario = veterinario;
        }

        return Page();
    }
}
