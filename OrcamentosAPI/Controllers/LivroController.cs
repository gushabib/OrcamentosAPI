using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using OrcamentosAPI.Data;
using OrcamentosAPI.Data.Dtos;
using OrcamentosAPI.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OrcamentosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LivroController : ControllerBase
    {
        private LivroContext _context;
        private IMapper _mapper;

        public LivroController(LivroContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaLivro(CreateLivroDto livroDto)
        {
            Livro livro = _mapper.Map<Livro>(livroDto);

            _context.Livros.Add(livro);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaLivroPorId), new { Id = livro.Id }, livro);

        }

        [HttpGet]
        public IEnumerable<Livro> RecuperaLivro()
        {
            return _context.Livros;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaLivroPorId(int id)
        {
            Livro livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);
            if (livro != null)
            {
                ReadLivroDto livroDto = _mapper.Map<ReadLivroDto>(livro);
                return Ok(livroDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaLivro(int id, [FromBody] UpdateLivroDto livroDto)
        {
            Livro livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);
            if (livro == null)
            {
                return NotFound();
            }
            _mapper.Map(livroDto, livro);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaLivro(int id)
        {
            Livro livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);
            if (livro == null)
            {
                return NotFound();
            }
            _context.Remove(livro);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
