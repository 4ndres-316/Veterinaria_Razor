using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using gestion_veterinaria.Models;
using gestion_veterinaria.Data;
using Microsoft.AspNetCore.Authorization;

namespace gestion_veterinaria.Pages.VeterinarioPages;

[Authorize(Roles = SeedData.RolAdmin)]
public class DeleteModel : PageModel
{
    private readonly VeterinariaContext _context;

    public DeleteModel(VeterinariaContext context)
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
        else
        {
            Veterinario = veterinario;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var veterinario = await _context.Veterinarios.FindAsync(id);
        if (veterinario != null)
        {
            Veterinario = veterinario;
            _context.Veterinarios.Remove(Veterinario);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
