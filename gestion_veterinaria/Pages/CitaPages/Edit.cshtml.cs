using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using gestion_veterinaria.Models;
using gestion_veterinaria.Data;

namespace gestion_veterinaria.Pages.CitaPages;

public class EditModel : PageModel
{
    private readonly VeterinariaContext _context;

    public EditModel(VeterinariaContext context)
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
        Cita = cita;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Cita).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CitaExists(Cita.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool CitaExists(int id)
    {
        return _context.Citas.Any(e => e.Id == id);
    }
}
