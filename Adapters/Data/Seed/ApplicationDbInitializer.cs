using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Data.Seed
{
    public class ApplicationDbInitializer
    {
        public static async Task SeedRolesAndUsersAsync(
           UserManager<UsuarioDomain> userManager,
           RoleManager<IdentityRole<Guid>> roleManager)
        {

            var adminUser = await userManager.FindByEmailAsync("admin@admin.com");
            if (adminUser == null)
            {
                adminUser = new UsuarioDomain
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    EmailConfirmed = true,
                    Nome = "Administrador"
                };

                var result = await userManager.CreateAsync(adminUser, "Admin@2026");

            }
        }

        public static void SeedCategoriasAsync(ModelBuilder builder)
        {
            builder.Entity<CategoriaDomain>().HasData(new List<CategoriaDomain>
            {
                new() { Id = Guid.Parse("b3644f1c-3b5f-4d69-a86d-66f8e7b172a1"), Nome = "Proteínas" },
                new() { Id = Guid.Parse("e5d1a8c2-7f3b-4e91-9a2c-5d8f6b4a3c1e"), Nome = "Hortifruti"},
                new() { Id = Guid.Parse("f8a2b1c3-4d5e-4f6a-8b7c-9d0e1f2a3b4c"), Nome = "Laticínios e Frios"},
                new() { Id = Guid.Parse("a1b2c3d4-e5f6-4a5b-8c7d-9e0f1a2b3c4d"), Nome = "Mercearia Seca"},
                new() { Id = Guid.Parse("1a2b3c4d-5e6f-4a5b-8c7d-9e0f1a2b3c4d"), Nome = "Temperos e Especiarias"},
                new() { Id = Guid.Parse("2b3c4d5e-6f7a-4b5c-9d8e-0f1a2b3c4d5e"), Nome = "Óleos e Gorduras"},
                new() { Id = Guid.Parse("3c4d5e6f-7a8b-4c5d-ae9f-1a2b3c4d5e6f"), Nome = "Padaria e Confeitaria"},
                new() { Id = Guid.Parse("4d5e6f7a-8b9c-4d5e-bfa0-2b3c4d5e6f7a"), Nome = "Molhos e Condimentos"},
                new() { Id = Guid.Parse("5e6f7a8b-9c0d-4e5f-c0b1-3c4d5e6f7a8b"), Nome = "Conservas e Enlatados" },
                new() { Id = Guid.Parse("6f7a8b9c-0d1e-4f5a-d1c2-4d5e6f7a8b9c"), Nome = "Bebidas Não Alcoólicas"},
                new() { Id = Guid.Parse("7a8b9c0d-1e2f-4a5b-e2d3-5e6f7a8b9c0d"), Nome = "Bebidas Alcoólicas" },
                new() { Id = Guid.Parse("8b9c0d1e-2f3a-4b5c-f3e4-6f7a8b9c0d1e"), Nome = "Insumos de Bar"},
                new() { Id = Guid.Parse("9c0d1e2f-3a4b-4c5d-04f5-7a8b9c0d1e2f"), Nome = "Embalagens e Descartáveis" },
                new() { Id = Guid.Parse("0d1e2f3a-4b5c-4d5e-1506-8b9c0d1e2f3a"), Nome = "Limpeza e Higiene" },
                new() { Id = Guid.Parse("1e2f3a4b-5c6d-4e5f-2617-9c0d1e2f3a4b"), Nome = "Produção Interna" }
            });
        }

    }
}
