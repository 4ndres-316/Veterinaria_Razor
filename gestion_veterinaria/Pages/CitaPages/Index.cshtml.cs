using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using gestion_veterinaria.Models;
using gestion_veterinaria.Data;
using Microsoft.AspNetCore.Authorization;

namespace gestion_veterinaria.Pages.CitaPages;

[Authorize(Roles = $"{SeedData.RolAdmin}, {SeedData.RolVeterinario}, {SeedData.RolCliente}")]
public class IndexModel : PageModel
{
    private readonly VeterinariaContext _context;

    public IndexModel(VeterinariaContext context)
    {
        _context = context;
    }

    public IList<Cita> Cita { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Cita = await _context.Citas.Include(m => m.Mascota).Include(v => v.Veterinario).ToListAsync();
    }
}
