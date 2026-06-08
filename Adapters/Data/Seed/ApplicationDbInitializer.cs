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

        public static void SeedUnidadesDeMedidasAsync(ModelBuilder builder)
        {
            builder.Entity<UnidadeMedidaDomain>().HasData(new List<UnidadeMedidaDomain>
            {
                
                new() { Id = UnidadesDeMedida.DEFAULT, Nome = "Não Aplicável", Sigla = "N/A" },
                new() { Id = Guid.Parse("f47ac10b-58cc-4372-a567-0e02b2c3d471"), Nome = "Quilograma", Sigla = "kg" },
                new() { Id = Guid.Parse("6e2b8f1a-9d3c-4b5a-8f1e-7c2d9a0b1c2d"), Nome = "Grama", Sigla = "g" },
                new() { Id = Guid.Parse("a1b2c3d4-e5f6-4a5b-bcde-f1234567890a"), Nome = "Miligrama", Sigla = "mg" },
                new() { Id = Guid.Parse("d9e8f7a6-b5c4-4d3e-2f1a-0b9c8d7e6f5a"), Nome = "Tonelada", Sigla = "t" },
                new() { Id = Guid.Parse("7b8a9c0d-1e2f-3a4b-5c6d-7e8f9a0b1c2d"), Nome = "Metro", Sigla = "m" },
                new() { Id = Guid.Parse("2d3e4f5a-6b7c-8d9e-0f1a-2b3c4d5e6f7a"), Nome = "Quilômetro", Sigla = "km" },
                new() { Id = Guid.Parse("a5b6c7d8-e9f0-1a2b-3c4d-5e6f7a8b9c0d"), Nome = "Centímetro", Sigla = "cm" },
                new() { Id = Guid.Parse("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), Nome = "Milímetro", Sigla = "mm" },
                new() { Id = Guid.Parse("f9e8d7c6-b5a4-3210-fedc-ba9876543210"), Nome = "Litro", Sigla = "L" },
                new() { Id = Guid.Parse("1a2b3c4d-5e6f-7a8b-9c0d-e1f2a3b4c5d6"), Nome = "Mililitro", Sigla = "ml" },
                new() { Id = Guid.Parse("b2c3d4e5-f6a7-8b9c-0d1e-2f3a4b5c6d7e"), Nome = "Metro Cúbico", Sigla = "m³" },
                new() { Id = Guid.Parse("3f4e5d6c-7b8a-9012-3456-789abcdef012"), Nome = "Metro Quadrado", Sigla = "m²" },
                new() { Id = Guid.Parse("5a6b7c8d-9e0f-1a2b-3c4d-5e6f7a8b9c0d"), Nome = "Hectare", Sigla = "ha" },
                new() { Id = Guid.Parse("e1f2a3b4-c5d6-7e8f-9a0b-1c2d3e4f5a6b"), Nome = "Quilômetro Quadrado", Sigla = "km²" },
                new() { Id = Guid.Parse("c7d8e9f0-1a2b-3c4d-5e6f-7a8b9c0d1e2f"), Nome = "Grau Celsius", Sigla = "°C" },
                new() { Id = Guid.Parse("6d5c4b3a-2e1f-0a9b-8c7d-6e5f4a3b2c1d"), Nome = "Unidade", Sigla = "un" },
                new() { Id = Guid.Parse("f1a2b3c4-d5e6-7a8b-9c0d-1e2f3a4b5c6d"), Nome = "Pacote", Sigla = "pct" },
                new() { Id = Guid.Parse("3d4e5f6a-7b8c-9d0e-1f2a-3b4c5d6e7f8a"), Nome = "Caixa", Sigla = "cx" }
            });
        }

        public static void SeedTiposDeMovimentacaoAsync(ModelBuilder builder)
        {
            builder.Entity<TipoMovimentacaoDomain>().HasData(new List<TipoMovimentacaoDomain>
            {
                
                new() { Id = TiposDeMovimentacao.ENTRADA, Nome = "Entrada" },
                new() { Id = TiposDeMovimentacao.SAIDA, Nome = "Saída" },
                new() { Id = TiposDeMovimentacao.DEVOLUCAO, Nome = "Devolução" },
                new() { Id = TiposDeMovimentacao.DESCARTE, Nome = "Descarte" },
                new() { Id = TiposDeMovimentacao.CORTESIA, Nome = "Cortesia" }
            });
        }

               
        

    }


}
