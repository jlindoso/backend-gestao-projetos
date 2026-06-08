using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Movimentacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovimentacoesEstoque_TiposSaida_TipoSaidaId",
                table: "MovimentacoesEstoque");

            migrationBuilder.DropTable(
                name: "TiposSaida");

            migrationBuilder.RenameColumn(
                name: "TipoSaidaId",
                table: "MovimentacoesEstoque",
                newName: "TipoMovimentacaoId");

            migrationBuilder.RenameColumn(
                name: "DataSaida",
                table: "MovimentacoesEstoque",
                newName: "DataMovimentacao");

            migrationBuilder.RenameIndex(
                name: "IX_MovimentacoesEstoque_TipoSaidaId",
                table: "MovimentacoesEstoque",
                newName: "IX_MovimentacoesEstoque_TipoMovimentacaoId");

            migrationBuilder.CreateTable(
                name: "TiposMovimentacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposMovimentacao", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TiposMovimentacao",
                columns: new[] { "Id", "Created", "Deleted", "Nome" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Entrada" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Saída" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Devolução" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Descarte" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Cortesia" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MovimentacoesEstoque_TiposMovimentacao_TipoMovimentacaoId",
                table: "MovimentacoesEstoque",
                column: "TipoMovimentacaoId",
                principalTable: "TiposMovimentacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovimentacoesEstoque_TiposMovimentacao_TipoMovimentacaoId",
                table: "MovimentacoesEstoque");

            migrationBuilder.DropTable(
                name: "TiposMovimentacao");

            migrationBuilder.RenameColumn(
                name: "TipoMovimentacaoId",
                table: "MovimentacoesEstoque",
                newName: "TipoSaidaId");

            migrationBuilder.RenameColumn(
                name: "DataMovimentacao",
                table: "MovimentacoesEstoque",
                newName: "DataSaida");

            migrationBuilder.RenameIndex(
                name: "IX_MovimentacoesEstoque_TipoMovimentacaoId",
                table: "MovimentacoesEstoque",
                newName: "IX_MovimentacoesEstoque_TipoSaidaId");

            migrationBuilder.CreateTable(
                name: "TiposSaida",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposSaida", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MovimentacoesEstoque_TiposSaida_TipoSaidaId",
                table: "MovimentacoesEstoque",
                column: "TipoSaidaId",
                principalTable: "TiposSaida",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
