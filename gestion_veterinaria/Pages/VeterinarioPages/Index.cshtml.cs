using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using gestion_veterinaria.Models;
using gestion_veterinaria.Data;
using Microsoft.AspNetCore.Authorization;

namespace gestion_veterinaria.Pages.VeterinarioPages;

public class IndexModel : PageModel
{
    private readonly VeterinariaContext _context;

    public IndexModel(VeterinariaContext context)
    {
        _context = context;
    }

    public IList<Veterinario> Veterinario { get; set; } = default!;

    [Authorize(Roles = "Admin, Veterinario")]
    public async Task OnGetAsync()
    {
        Veterinario = await _context.Veterinarios.ToListAsync();
    }
}
