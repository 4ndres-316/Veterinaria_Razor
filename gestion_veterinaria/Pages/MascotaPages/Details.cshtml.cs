using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using gestion_veterinaria.Models;
using gestion_veterinaria.Data;

namespace gestion_veterinaria.Pages.MascotaPages;

public class DetailsModel : PageModel
{
    private readonly VeterinariaContext _context;
    public DetailsModel(VeterinariaContext context)
    {
        _context = context;
    }

    public Mascota Mascota { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var mascota = await _context.Mascotas.FirstOrDefaultAsync(m => m.Id == id);
        if (mascota is null)
        {
            return NotFound();
        }
        else
        {
            Mascota = mascota;
        }

        return Page();
    }
}
