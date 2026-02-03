using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Paciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultaDomain_AspNetUsers_AtendenteId",
                table: "ConsultaDomain");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultaDomain_AspNetUsers_MedicoId",
                table: "ConsultaDomain");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultaDomain_AspNetUsers_PacienteId",
                table: "ConsultaDomain");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultaDomain_StatusConsultaDomain_StatusId",
                table: "ConsultaDomain");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultaDomain_TipoConsultaDomain_TipoId",
                table: "ConsultaDomain");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsultaDomain",
                table: "ConsultaDomain");

            migrationBuilder.RenameTable(
                name: "ConsultaDomain",
                newName: "Consultas");

            migrationBuilder.RenameIndex(
                name: "IX_ConsultaDomain_TipoId",
                table: "Consultas",
                newName: "IX_Consultas_TipoId");

            migrationBuilder.RenameIndex(
                name: "IX_ConsultaDomain_StatusId",
                table: "Consultas",
                newName: "IX_Consultas_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ConsultaDomain_PacienteId",
                table: "Consultas",
                newName: "IX_Consultas_PacienteId");

            migrationBuilder.RenameIndex(
                name: "IX_ConsultaDomain_MedicoId",
                table: "Consultas",
                newName: "IX_Consultas_MedicoId");

            migrationBuilder.RenameIndex(
                name: "IX_ConsultaDomain_AtendenteId",
                table: "Consultas",
                newName: "IX_Consultas_AtendenteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consultas",
                table: "Consultas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Enfermeiros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    COREN = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermeiros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enfermeiros_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    CRM = table.Column<string>(type: "text", nullable: false),
                    Especialidade = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicos_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    RG = table.Column<string>(type: "text", nullable: false),
                    Emissor = table.Column<string>(type: "text", nullable: false),
                    UF = table.Column<string>(type: "text", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    NumeroPlanoSaude = table.Column<string>(type: "text", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enfermeiros_UsuarioId",
                table: "Enfermeiros",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_UsuarioId",
                table: "Medicos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_UsuarioId",
                table: "Pacientes",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_AspNetUsers_AtendenteId",
                table: "Consultas",
                column: "AtendenteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Medicos_MedicoId",
                table: "Consultas",
                column: "MedicoId",
                principalTable: "Medicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Pacientes_PacienteId",
                table: "Consultas",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_StatusConsultaDomain_StatusId",
                table: "Consultas",
                column: "StatusId",
                principalTable: "StatusConsultaDomain",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_TipoConsultaDomain_TipoId",
                table: "Consultas",
                column: "TipoId",
                principalTable: "TipoConsultaDomain",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_AspNetUsers_AtendenteId",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Medicos_MedicoId",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Pacientes_PacienteId",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_StatusConsultaDomain_StatusId",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_TipoConsultaDomain_TipoId",
                table: "Consultas");

            migrationBuilder.DropTable(
                name: "Enfermeiros");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Consultas",
                table: "Consultas");

            migrationBuilder.RenameTable(
                name: "Consultas",
                newName: "ConsultaDomain");

            migrationBuilder.RenameIndex(
                name: "IX_Consultas_TipoId",
                table: "ConsultaDomain",
                newName: "IX_ConsultaDomain_TipoId");

            migrationBuilder.RenameIndex(
                name: "IX_Consultas_StatusId",
                table: "ConsultaDomain",
                newName: "IX_ConsultaDomain_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Consultas_PacienteId",
                table: "ConsultaDomain",
                newName: "IX_ConsultaDomain_PacienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Consultas_MedicoId",
                table: "ConsultaDomain",
                newName: "IX_ConsultaDomain_MedicoId");

            migrationBuilder.RenameIndex(
                name: "IX_Consultas_AtendenteId",
                table: "ConsultaDomain",
                newName: "IX_ConsultaDomain_AtendenteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConsultaDomain",
                table: "ConsultaDomain",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultaDomain_AspNetUsers_AtendenteId",
                table: "ConsultaDomain",
                column: "AtendenteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultaDomain_AspNetUsers_MedicoId",
                table: "ConsultaDomain",
                column: "MedicoId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultaDomain_AspNetUsers_PacienteId",
                table: "ConsultaDomain",
                column: "PacienteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultaDomain_StatusConsultaDomain_StatusId",
                table: "ConsultaDomain",
                column: "StatusId",
                principalTable: "StatusConsultaDomain",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultaDomain_TipoConsultaDomain_TipoId",
                table: "ConsultaDomain",
                column: "TipoId",
                principalTable: "TipoConsultaDomain",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
