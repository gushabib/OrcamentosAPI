using OrcamentosAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OrcamentosAPI.Data.Dtos
{
    public class UpdateOrcamentoDto
    {
        [Required]
        public double QtdLivros { get; set; }
        [Required]
        public double ValorPorPagina { get; set; }
        [Required]
        public double ComissaoVendedor { get; set; }
    }
}