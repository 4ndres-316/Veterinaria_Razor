using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class gestion_veterinariaContext(DbContextOptions<gestion_veterinariaContext> options) : IdentityDbContext<gestion_veterinaria.Data.ApplicationUser>(options)
{
}
