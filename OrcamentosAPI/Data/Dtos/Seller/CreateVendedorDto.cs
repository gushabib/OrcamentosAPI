using OrcamentosAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OrcamentosAPI.Data.Dtos.Seller
{
    public class CreateVendedorDto
    {
        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo CPF é obrigatório!")]
        public string CPF { get; set; }
        [Required]
        public double Comissao { get; set; }
    }
}
