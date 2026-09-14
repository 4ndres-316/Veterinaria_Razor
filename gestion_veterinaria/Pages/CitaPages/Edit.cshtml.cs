using gestion_veterinaria.Data;
using gestion_veterinaria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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

    [Authorize(Roles = "Admin, Veterinario")]
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

        ViewData["MascotaId"] = new SelectList(_context.Mascotas, "Id", "Nombre", Cita.MascotaId);
        ViewData["VeterinarioId"] = new SelectList(_context.Veterinarios, "Id", "Nombre", Cita.VeterinarioId);

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
