using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Seed;
using Domain.Model;
using Domain.Model.NotaFiscal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataDBContext : IdentityDbContext<UsuarioDomain, IdentityRole<Guid>, Guid>
    {
        public DataDBContext(DbContextOptions<DataDBContext> options) : base(options)
        {

        }

        public DbSet<CategoriaDomain> Categorias { get; set; }
        public DbSet<CategoriaProdutoDomain> CategoriasProdutos { get; set; }
        public DbSet<EstoqueDomain> Estoques { get; set; }
        public DbSet<MovimentacaoEstoqueDomain> MovimentacoesEstoque { get; set; }
        public DbSet<ProdutoDomain> Produtos { get; set; }
        public DbSet<UnidadeMedidaDomain> UnidadesMedida { get; set; }
        public DbSet<TipoSaidaDomain> TiposSaida { get; set; }
        public DbSet<NotaFiscalDomain> NotasFiscais { get; set; }
        public DbSet<ItemNFDomain> ItensNotaFiscal { get; set; }
        public DbSet<TipoEmissaoNFDomain> TiposEmissaoNF { get; set; }
        public DbSet<TipoOperacaoNFDomain> TiposOperacaoNF { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            Data.Seed.ApplicationDbInitializer.SeedCategoriasAsync(builder);
        }
    }


}