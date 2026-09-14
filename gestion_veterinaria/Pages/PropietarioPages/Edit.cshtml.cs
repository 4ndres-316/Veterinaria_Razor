using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using gestion_veterinaria.Models;
using gestion_veterinaria.Data;

namespace gestion_veterinaria.Pages.PropietarioPages;

public class EditModel : PageModel
{
    private readonly VeterinariaContext _context;

    public EditModel(VeterinariaContext context)
    {
        _context = context;
    }

    [BindProperty]
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
        Propietario = propietario;
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

        _context.Attach(Propietario).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PropietarioExists(Propietario.Id))
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

    private bool PropietarioExists(int id)
    {
        return _context.Propietarios.Any(e => e.Id == id);
    }
}
