using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using gestion_veterinaria.Models;
using gestion_veterinaria.Data;

namespace gestion_veterinaria.Pages.PropietarioPages;

public class IndexModel : PageModel
{
    private readonly VeterinariaContext _context;

    public IndexModel(VeterinariaContext context)
    {
        _context = context;
    }

    public IList<Propietario> Propietario { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Propietario = await _context.Propietarios.ToListAsync();
    }
}
