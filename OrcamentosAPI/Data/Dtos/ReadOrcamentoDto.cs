using OrcamentosAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OrcamentosAPI.Data.Dtos
{
    public class ReadOrcamentoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public double ValorPorPagina { get; set; }
        public double ValorPorLivro { get; set; }
        public double ValorTotalLivros { get; set; }
        [Required]
        public double ComissaoVendedor { get; set; }
        public virtual Livro Livro { get; set; }
        public int LivroId { get; set; }
    }
}