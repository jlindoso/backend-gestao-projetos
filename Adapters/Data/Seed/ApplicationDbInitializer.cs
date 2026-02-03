using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.AspNetCore.Identity;

namespace Data.Seed
{
    public class ApplicationDbInitializer
    {
         public static async Task SeedRolesAndUsersAsync(
            UserManager<UsuarioDomain> userManager,
            RoleManager<IdentityRole<Guid>> roleManager) 
    {
        if (!await roleManager.RoleExistsAsync(PerfilDomain.Administrador))
        {
            await roleManager.CreateAsync(new IdentityRole<Guid>
                {
                    Id = Guid.NewGuid(),
                    Name = PerfilDomain.Administrador,
                    NormalizedName = PerfilDomain.Administrador.ToUpper()
                    
                });
        }

        if (!await roleManager.RoleExistsAsync(PerfilDomain.Paciente))
        {
            await roleManager.CreateAsync(new IdentityRole<Guid>
                {
                    Id = Guid.NewGuid(),
                    Name = PerfilDomain.Paciente,
                    NormalizedName = PerfilDomain.Paciente.ToUpper()
                    
                });
        }

        
        var adminUser = await userManager.FindByEmailAsync("admin@admin.com");
        if (adminUser == null)
        {
            adminUser = new UsuarioDomain
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                CPF = "00000000000", 
                EmailConfirmed = true,
                NomeSocial = "Administrador"
            };

            var result = await userManager.CreateAsync(adminUser, "Admin@2026");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, PerfilDomain.Administrador);
            }
            else
            {
                Console.WriteLine($"Erro ao criar usuário admin: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }
        else
        {
            if (!await userManager.IsInRoleAsync(adminUser, PerfilDomain.Administrador))
            {
                await userManager.AddToRoleAsync(adminUser, PerfilDomain.Administrador);
            }
        }
    }
    }
}