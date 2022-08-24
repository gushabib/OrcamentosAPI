using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OrcamentosAPI.Models
{
    public class Produto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="O campo nome é obrigatório!")]
        public string Nome { get; set; }
        [Required(ErrorMessage ="O campo tipo é obrigatório!")]
        public string Tipo { get; set; }
        [Required(ErrorMessage ="O campo valor é obrigatório!")]
        public double Valor { get; set; }
        [JsonIgnore]
        public virtual List<Orcamento> Orcamentos { get; set; }

    }
}
