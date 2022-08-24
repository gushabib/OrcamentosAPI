using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OrcamentosAPI.Models
{
    public class Vendedor
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo CPF é obrigatório!")]
        public string CPF { get; set; }
        [Required]
        public double Comissao { get; set; }
        [JsonIgnore]
        public virtual List<Orcamento> Orcamentos { get; set; }
        [JsonIgnore]
        public virtual List<Produto> Produtos { get; set; }
    }
}
