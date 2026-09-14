using gestion_veterinaria.Data;
using gestion_veterinaria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace gestion_veterinaria.Pages.CitaPages;

public class CreateModel : PageModel
{
    private readonly VeterinariaContext _context;

    public CreateModel(VeterinariaContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        ViewData["MascotaId"] = new SelectList(_context.Mascotas, "Id", "Nombre");
        ViewData["VeterinarioId"] = new SelectList(_context.Veterinarios, "Id", "Nombre");

        return Page();
    }

    [BindProperty]
    public Cita Cita { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Citas.Add(Cita);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
