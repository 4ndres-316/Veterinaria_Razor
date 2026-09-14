using Microsoft.AspNetCore.Identity;

namespace gestion_veterinaria.Data;

public static class SeedData
{
    // Roles del sistema
    public const string RolAdmin = "Admin";
    public const string RolVeterinario = "Veterinario";
    public const string RolCliente = "Cliente";

    // Usuarios iniciales
    private const string AdminEmail = "admin@veterinaria.com";
    private const string AdminPassword = "Admin1234";

    private const string VetEmail = "veterinario@veterinaria.com";
    private const string VetPassword = "Vet1234";

    private const string ClienteEmail = "cliente@veterinaria.com";
    private const string ClientePassword = "Cliente1234";

    public static async Task InicializarAsync(IServiceProvider services)
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

        // ── Crear roles ──────────────────────────────────────────────────────
        await CrearRolSiNoExisteAsync(roleManager, RolAdmin);
        await CrearRolSiNoExisteAsync(roleManager, RolVeterinario);
        await CrearRolSiNoExisteAsync(roleManager, RolCliente);

        // ── Crear usuario Admin ───────────────────────────────────────────────
        await CrearUsuarioSiNoExisteAsync(userManager, AdminEmail, AdminPassword, RolAdmin);

        // ── Crear usuario Veterinario ─────────────────────────────────────────
        await CrearUsuarioSiNoExisteAsync(userManager, VetEmail, VetPassword, RolVeterinario);

        // ── Crear usuario Cliente ─────────────────────────────────────────────
        await CrearUsuarioSiNoExisteAsync(userManager, ClienteEmail, ClientePassword, RolCliente);
    }

    private static async Task CrearRolSiNoExisteAsync(RoleManager<IdentityRole> roleManager, string rol)
    {
        if (!await roleManager.RoleExistsAsync(rol))
        {
            await roleManager.CreateAsync(new IdentityRole(rol));
        }
    }

    private static async Task CrearUsuarioSiNoExisteAsync(
        UserManager<ApplicationUser> userManager,
        string email,
        string password,
        string rol)
    {
        if (await userManager.FindByEmailAsync(email) is null)
        {
            var usuario = new ApplicationUser
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true
            };

            var resultado = await userManager.CreateAsync(usuario, password);

            if (resultado.Succeeded)
            {
                await userManager.AddToRoleAsync(usuario, rol);
            }
        }
    }
}
