using Jcf.QuinzePontos.Domain.Constants;
using Jcf.QuinzePontos.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Jcf.QuinzePontos.Api.Startup
{
    public static class IdentitySeeder
    {
        public static async Task SeedAsync(IServiceProvider services, IConfiguration configuration)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var logger = services.GetRequiredService<ILogger<ApplicationUser>>();

            foreach (var role in Roles.All)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole<Guid>(role));
            }

            var adminSection = configuration.GetSection("AdminSeed");
            var adminEmail = adminSection["Email"];
            var adminPassword = adminSection["Password"];

            if (string.IsNullOrWhiteSpace(adminEmail) || string.IsNullOrWhiteSpace(adminPassword))
            {
                logger.LogWarning("AdminSeed não configurado (AdminSeed:Email / AdminSeed:Password). Nenhum usuário Admin inicial foi criado.");
                return;
            }

            if (await userManager.FindByEmailAsync(adminEmail) != null)
                return;

            var adminUser = new ApplicationUser(
                fullName: adminSection["FullName"] ?? "Administrador",
                email: adminEmail,
                phoneNumber: adminSection["PhoneNumber"]);

            var createResult = await userManager.CreateAsync(adminUser, adminPassword);
            if (!createResult.Succeeded)
            {
                logger.LogError("Falha ao criar o usuário Admin inicial: {Errors}",
                    string.Join("; ", createResult.Errors.Select(e => e.Description)));
                return;
            }

            await userManager.AddToRoleAsync(adminUser, Roles.Admin);
            logger.LogInformation("Usuário Admin inicial criado a partir do AdminSeed.");
        }
    }
}
