using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using gestion_veterinaria.Models;
using gestion_veterinaria.Data;

namespace gestion_veterinaria.Pages.VeterinarioPages;

public class EditModel : PageModel
{
    private readonly VeterinariaContext _context;

    public EditModel(VeterinariaContext context)
    {
        _context = context;
    }

    [BindProperty]
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
        Veterinario = veterinario;
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

        _context.Attach(Veterinario).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VeterinarioExists(Veterinario.Id))
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

    private bool VeterinarioExists(int id)
    {
        return _context.Veterinarios.Any(e => e.Id == id);
    }
}
