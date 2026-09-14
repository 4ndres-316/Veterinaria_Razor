using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using gestion_veterinaria.Models;
using gestion_veterinaria.Data;
using Microsoft.AspNetCore.Authorization;

namespace gestion_veterinaria.Pages.PropietarioPages;

[Authorize(Roles = $"{SeedData.RolAdmin}, {SeedData.RolVeterinario}, {SeedData.RolCliente}")]
public class DetailsModel : PageModel
{
    private readonly VeterinariaContext _context;
    public DetailsModel(VeterinariaContext context)
    {
        _context = context;
    }

    public Propietario Propietario { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var propietario = await _context.Propietarios.FirstOrDefaultAsync(m => m.Id == id);
        if (propietario is null)
        {
            return NotFound();
        }
        else
        {
            Propietario = propietario;
        }

        return Page();
    }
}
