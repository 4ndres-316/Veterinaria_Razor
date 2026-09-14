using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using gestion_veterinaria.Models;
using gestion_veterinaria.Data;
using Microsoft.AspNetCore.Authorization;

namespace gestion_veterinaria.Pages.VeterinarioPages;

public class CreateModel : PageModel
{
    private readonly VeterinariaContext _context;

    public CreateModel(VeterinariaContext context)
    {
        _context = context;
    }

    [Authorize(Roles = "Admin, Veterinario")]
    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Veterinario Veterinario { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Veterinarios.Add(Veterinario);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
