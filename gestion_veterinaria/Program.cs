using gestion_veterinaria.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// BASE DE DATOS DE LA VETERINARIA

builder.Services.AddDbContext<VeterinariaContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// BASE DE DATOS DE IDENTITY

builder.Services.AddDbContext<gestion_veterinariaContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("IdentityConnection")
    ));

// IDENTITY

builder.Services
    .AddDefaultIdentity<ApplicationUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;

        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 4;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<gestion_veterinariaContext>();

// RAZOR PAGES

builder.Services.AddRazorPages();


var app = builder.Build();

// CONFIGURACION DEL ENTORNO

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

// AUTENTICACION Y AUTORIZACION

app.UseAuthentication();
app.UseAuthorization();

// RAZOR PAGES

app.MapStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

// SEED DE ROLES Y USUARIOS INICIALES

using (var scope = app.Services.CreateScope())
{
    await gestion_veterinaria.Data.SeedData.InicializarAsync(scope.ServiceProvider);
}

app.Run();