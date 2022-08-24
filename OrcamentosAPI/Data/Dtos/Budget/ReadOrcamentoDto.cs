using OrcamentosAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OrcamentosAPI.Data.Dtos.Budget
{
    public class ReadOrcamentoDto
    {
        public int Id { get; set; }
        public double QtdProdutos { get; set; }
        public double ValorTotalProdutos { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual Vendedor Vendedor { get; set; }
    }
}