using OrcamentosAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OrcamentosAPI.Data.Dtos.Product
{
    public class CreateProdutoDto
    {
        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo tipo é obrigatório!")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "O campo valor é obrigatório!")]
        public double Valor { get; set; }
    }
}
