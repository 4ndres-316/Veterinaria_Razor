using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using gestion_veterinaria.Models;
using gestion_veterinaria.Data;

namespace gestion_veterinaria.Pages.MascotaPages;

public class DeleteModel : PageModel
{
    private readonly VeterinariaContext _context;

    public DeleteModel(VeterinariaContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Mascota Mascota { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var mascota = await _context.Mascotas.Include(m => m.Propietario).FirstOrDefaultAsync(m => m.Id == id);
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var mascota = await _context.Mascotas.FindAsync(id);
        if (mascota != null)
        {
            Mascota = mascota;
            _context.Mascotas.Remove(Mascota);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
