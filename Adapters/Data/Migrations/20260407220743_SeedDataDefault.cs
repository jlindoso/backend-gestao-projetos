using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UnidadesMedida",
                columns: new[] { "Id", "Created", "Deleted", "Nome", "Sigla" },
                values: new object[] { new Guid("2700cf0d-3757-4869-b730-afa9ee7fb89f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Não Aplicável", "N/A" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: new Guid("2700cf0d-3757-4869-b730-afa9ee7fb89f"));
        }
    }
}
