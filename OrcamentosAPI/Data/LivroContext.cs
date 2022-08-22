using Microsoft.EntityFrameworkCore;
using OrcamentosAPI.Models;

namespace OrcamentosAPI.Data
{
    public class LivroContext : DbContext
    {
        public LivroContext(DbContextOptions<LivroContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Orcamento>()
                .HasOne(orcamento => orcamento.Livro)//Relacionamento 1:n
                .WithMany(livro => livro.Orcamentos)
                .HasForeignKey(orcamento => orcamento.LivroId); //.IsRequired(False); Conseguiria criar um cinema sem Gerente
                                                                //.OnDelete(DeleteBehavior.Restrict); //Remove o Casdade Caso algum projeto não precise
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Orcamento> Orcamentos { get; set; }
    }
}
