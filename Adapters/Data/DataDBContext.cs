using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataDBContext : IdentityDbContext<UsuarioDomain, IdentityRole<Guid>, Guid>
    {
        public DataDBContext(DbContextOptions<DataDBContext> options) : base(options)
        {
            // dotnet ef migrations add Paciente --startup-project ../../Application
        }

        public DbSet<PacienteDomain> Pacientes { get; set; }
        public DbSet<ConsultaDomain> Consultas { get; set; }
        public DbSet<MedicoDomain> Medicos { get; set; }
         public DbSet<EnfermeiroDomain> Enfermeiros { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PacienteDomain>()
            .HasOne(p => p.Usuario)
            .WithOne() // se não houver coleção inversa
            .HasForeignKey<PacienteDomain>(p => p.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UsuarioDomain>(entity =>
            {
                entity.Property(e => e.CPF).HasMaxLength(11).IsRequired();
                entity.HasIndex(e => e.CPF).IsUnique();

                // sexo
                entity.HasOne(u => u.SexoBiologico)
                    .WithMany()
                    .HasForeignKey(u => u.SexoId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Gênero (opcional)
                entity.HasOne(u => u.Genero)
                    .WithMany()
                    .HasForeignKey(u => u.GeneroId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<ConsultaDomain>(entity =>
            {
                // Paciente (obrigatório)
                entity.HasOne(c => c.Paciente)
                    .WithMany() // se Paciente não tiver coleção de consultas
                    .HasForeignKey(c => c.PacienteId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Médico (opcional)
                entity.HasOne(c => c.Medico)
                    .WithMany() // se Medico não tiver coleção de consultas
                    .HasForeignKey(c => c.MedicoId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Atendente (opcional)
                entity.HasOne(c => c.Atendente)
                    .WithMany() // se Atendente não tiver coleção de consultas
                    .HasForeignKey(c => c.AtendenteId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Status (obrigatório)
                entity.HasOne(c => c.Status)
                    .WithMany() // se Status não tiver coleção de consultas
                    .HasForeignKey(c => c.StatusId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Tipo (obrigatório)
                entity.HasOne(c => c.Tipo)
                    .WithMany() // se Tipo não tiver coleção de consultas
                    .HasForeignKey(c => c.TipoId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<StatusConsultaDomain>(entity =>
            {
                entity.Property(s => s.Nome)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasData(
                    new StatusConsultaDomain
                    {
                        Id = StatusConsultaIds.Agendada,
                        Nome = "Agendada"
                    },
                    new StatusConsultaDomain
                    {
                        Id = StatusConsultaIds.Confirmada,
                        Nome = "Confirmada"
                    },
                    new StatusConsultaDomain
                    {
                        Id = StatusConsultaIds.EmAtendimento,
                        Nome = "Em Atendimento"
                    },
                    new StatusConsultaDomain
                    {
                        Id = StatusConsultaIds.Finalizada,
                        Nome = "Finalizada"
                    },
                    new StatusConsultaDomain
                    {
                        Id = StatusConsultaIds.Cancelada,
                        Nome = "Cancelada"
                    },
                    new StatusConsultaDomain
                    {
                        Id = StatusConsultaIds.NaoCompareceu,
                        Nome = "Não Compareceu"
                    }
                );
            });

            builder.Entity<TipoConsultaDomain>(entity =>
            {
                entity.Property(t => t.Nome)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasData(
                    new TipoConsultaDomain
                    {
                        Id = TipoConsultaIds.Consulta,
                        Nome = "Consulta"
                    },
                    new TipoConsultaDomain
                    {
                        Id = TipoConsultaIds.Retorno,
                        Nome = "Retorno"
                    },
                    new TipoConsultaDomain
                    {
                        Id = TipoConsultaIds.Procedimento,
                        Nome = "Procedimento"
                    }
                );
            });

            builder.Entity<SexoDomain>(entity =>
            {
                entity.Property(s => s.Nome)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(s => s.Biologico)
                    .IsRequired();

                entity.HasData(
                    // Sexo biológico
                    new SexoDomain
                    {
                        Id = SexoIds.MasculinoBiologico,
                        Nome = "Masculino",
                        Biologico = true
                    },
                    new SexoDomain
                    {
                        Id = SexoIds.FemininoBiologico,
                        Nome = "Feminino",
                        Biologico = true
                    },
                    new SexoDomain
                    {
                        Id = SexoIds.Intersexo,
                        Nome = "Intersexo",
                        Biologico = true
                    },

                    // Gênero / Identidade
                    new SexoDomain
                    {
                        Id = SexoIds.Homem,
                        Nome = "Homem",
                        Biologico = false
                    },
                    new SexoDomain
                    {
                        Id = SexoIds.Mulher,
                        Nome = "Mulher",
                        Biologico = false
                    },
                    new SexoDomain
                    {
                        Id = SexoIds.NaoBinario,
                        Nome = "Não-binário",
                        Biologico = false
                    },
                    new SexoDomain
                    {
                        Id = SexoIds.Outro,
                        Nome = "Outro",
                        Biologico = false
                    },
                    new SexoDomain
                    {
                        Id = SexoIds.PrefereNaoInformar,
                        Nome = "Prefere não informar",
                        Biologico = false
                    }
                );
            });

        }
    }


}