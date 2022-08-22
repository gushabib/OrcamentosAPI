using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OrcamentosAPI.Models
{
    public class Livro
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="O campo título é obrigatório!")]
        public string Titulo { get; set; }
        [Required(ErrorMessage ="O campo autor é obrigatório!")]
        public string Autor { get; set; }
        [Required(ErrorMessage ="O campo gênero é obrigatório!")]
        public string Genero { get; set; }
        [Range(5,9999, ErrorMessage ="O livro deve ter de 5 a 9999 páginas.")]
        public int QtdPaginas { get; set; }
        [JsonIgnore]
        public virtual List<Orcamento> Orcamentos { get; set; }
    }
}
