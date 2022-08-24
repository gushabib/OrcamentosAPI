using Microsoft.EntityFrameworkCore;
using OrcamentosAPI.Models;

namespace OrcamentosAPI.Data
{
    public class DbAppContext : DbContext
    {
        public DbAppContext(DbContextOptions<DbAppContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Orcamento>()
                .HasOne(orcamento => orcamento.Produto)
                .WithMany(produto => produto.Orcamentos)
                .HasForeignKey(orcamento => orcamento.ProdutoId);

            builder.Entity<Orcamento>()
                .HasOne(orcamento => orcamento.Vendedor)
                .WithMany(vendedor => vendedor.Orcamentos)
                .HasForeignKey(orcamento => orcamento.VendedorId);

        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Orcamento> Orcamentos { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
    }
}
