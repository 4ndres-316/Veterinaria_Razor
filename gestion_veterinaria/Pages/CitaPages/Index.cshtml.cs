using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using gestion_veterinaria.Models;
using gestion_veterinaria.Data;

namespace gestion_veterinaria.Pages.CitaPages;

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
        Cita = await _context.Citas.ToListAsync();
    }
}
