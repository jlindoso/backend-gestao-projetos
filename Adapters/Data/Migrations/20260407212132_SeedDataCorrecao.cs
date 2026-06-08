using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataCorrecao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UnidadesMedida",
                columns: new[] { "Id", "Created", "Deleted", "Nome", "Sigla" },
                values: new object[,]
                {
                    { new Guid("1a2b3c4d-5e6f-7a8b-9c0d-e1f2a3b4c5d6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Mililitro", "ml" },
                    { new Guid("2d3e4f5a-6b7c-8d9e-0f1a-2b3c4d5e6f7a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Quilômetro", "km" },
                    { new Guid("3d4e5f6a-7b8c-9d0e-1f2a-3b4c5d6e7f8a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Caixa", "cx" },
                    { new Guid("3f4e5d6c-7b8a-9012-3456-789abcdef012"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Metro Quadrado", "m²" },
                    { new Guid("5a6b7c8d-9e0f-1a2b-3c4d-5e6f7a8b9c0d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Hectare", "ha" },
                    { new Guid("6d5c4b3a-2e1f-0a9b-8c7d-6e5f4a3b2c1d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Unidade", "un" },
                    { new Guid("6e2b8f1a-9d3c-4b5a-8f1e-7c2d9a0b1c2d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Grama", "g" },
                    { new Guid("7b8a9c0d-1e2f-3a4b-5c6d-7e8f9a0b1c2d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Metro", "m" },
                    { new Guid("a1b2c3d4-e5f6-4a5b-bcde-f1234567890a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Miligrama", "mg" },
                    { new Guid("a5b6c7d8-e9f0-1a2b-3c4d-5e6f7a8b9c0d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Centímetro", "cm" },
                    { new Guid("b2c3d4e5-f6a7-8b9c-0d1e-2f3a4b5c6d7e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Metro Cúbico", "m³" },
                    { new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Milímetro", "mm" },
                    { new Guid("c7d8e9f0-1a2b-3c4d-5e6f-7a8b9c0d1e2f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Grau Celsius", "°C" },
                    { new Guid("d9e8f7a6-b5c4-4d3e-2f1a-0b9c8d7e6f5a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Tonelada", "t" },
                    { new Guid("e1f2a3b4-c5d6-7e8f-9a0b-1c2d3e4f5a6b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Quilômetro Quadrado", "km²" },
                    { new Guid("f1a2b3c4-d5e6-7a8b-9c0d-1e2f3a4b5c6d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Pacote", "pct" },
                    { new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d471"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Quilograma", "kg" },
                    { new Guid("f9e8d7c6-b5a4-3210-fedc-ba9876543210"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Litro", "L" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: new Guid("1a2b3c4d-5e6f-7a8b-9c0d-e1f2a3b4c5d6"));

            migrationBuilder.DeleteData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: new Guid("2d3e4f5a-6b7c-8d9e-0f1a-2b3c4d5e6f7a"));

            migrationBuilder.DeleteData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: new Guid("3d4e5f6a-7b8c-9d0e-1f2a-3b4c5d6e7f8a"));

            migrationBuilder.DeleteData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: new Guid("3f4e5d6c-7b8a-9012-3456-789abcdef012"));

            migrationBuilder.DeleteData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: new Guid("5a6b7c8d-9e0f-1a2b-3c4d-5e6f7a8b9c0d"));

            migrationBuilder.DeleteData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: new Guid("6d5c4b3a-2e1f-0a9b-8c7d-6e5f4a3b2c1d"));

            migrationBuilder.DeleteData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: new Guid("6e2b8f1a-9d3c-4b5a-8f1e-7c2d9a0b1c2d"));

            migrationBuilder.DeleteData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: new Guid("7b8a9c0d-1e2f-3a4b-5c6d-7e8f9a0b1c2d"));

            migrationBuilder.DeleteData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a5b-bcde-f1234567890a"));

            migrationBuilder.DeleteData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: new Guid("a5b6c7d8-e9f0-1a2b-3c4d-5e6f7a8b9c0d"));

            migrationBuilder.DeleteData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a7-8b9c-0d1e-2f3a4b5c6d7e"));

            migrationBuilder.DeleteData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: new Guid("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"));

            migrationBuilder.DeleteData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: new Guid("c7d8e9f0-1a2b-3c4d-5e6f-7a8b9c0d1e2f"));

            migrationBuilder.DeleteData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: new Guid("d9e8f7a6-b5c4-4d3e-2f1a-0b9c8d7e6f5a"));

            migrationBuilder.DeleteData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: new Guid("e1f2a3b4-c5d6-7e8f-9a0b-1c2d3e4f5a6b"));

            migrationBuilder.DeleteData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: new Guid("f1a2b3c4-d5e6-7a8b-9c0d-1e2f3a4b5c6d"));

            migrationBuilder.DeleteData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d471"));

            migrationBuilder.DeleteData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: new Guid("f9e8d7c6-b5a4-3210-fedc-ba9876543210"));
        }
    }
}
