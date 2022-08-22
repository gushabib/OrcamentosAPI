using OrcamentosAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OrcamentosAPI.Data.Dtos
{
    public class CreateOrcamentoDto
    {
        [Required]
        public double QtdLivros { get; set; }
        [Required]
        public double ValorPorPagina { get; set; }
        [JsonIgnore]
        public double ValorPorLivro { get; set; }
        [JsonIgnore]
        public double ValorTotalLivros { get; set; }
        [Required]
        public double ComissaoVendedor { get; set; }
        [JsonIgnore]
        public int LivroId { get; set; }
    }
}