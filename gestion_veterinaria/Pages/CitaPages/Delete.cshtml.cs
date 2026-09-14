using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using gestion_veterinaria.Models;
using gestion_veterinaria.Data;

namespace gestion_veterinaria.Pages.CitaPages;

public class DeleteModel : PageModel
{
    private readonly VeterinariaContext _context;

    public DeleteModel(VeterinariaContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Cita Cita { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var cita = await _context.Citas.FirstOrDefaultAsync(m => m.Id == id);
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var cita = await _context.Citas.FindAsync(id);
        if (cita != null)
        {
            Cita = cita;
            _context.Citas.Remove(Cita);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
