using System.ComponentModel.DataAnnotations;

namespace OrcamentosAPI.Models
{
    public class Orcamento
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public double QtdLivros { get; set; }
        public double ValorPorPagina { get; set; }
        public double ValorPorLivro { get; set; }
        public double ValorTotalLivros { get; set; }
        [Required]
        public double ComissaoVendedor { get; set; }
        public virtual Livro Livro { get; set; }
        public int LivroId { get; set; }
    }
}
