using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OrcamentosAPI.Models
{
    public class Orcamento
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int ProdutoId { get; set; }
        [Required]
        public int VendedorId { get; set; }
        [Required]
        public double QtdProdutos { get; set; }
        [JsonIgnore]
        public double ValorTotalProdutos { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual Vendedor Vendedor { get; set; }
    }
}
