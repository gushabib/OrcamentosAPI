using OrcamentosAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OrcamentosAPI.Data.Dtos.Budget
{
    public class CreateOrcamentoDto
    {
        [Required]
        public int ProdutoId { get; set; }
        [Required]
        public int VendedorId { get; set; }
        [Required]
        public double QtdProdutos { get; set; }
    }
}