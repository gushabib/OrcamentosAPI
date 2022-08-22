using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrcamentosAPI.Data;
using OrcamentosAPI.Data.Dtos;
using OrcamentosAPI.Models;

namespace OrcamentosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrcamentoController : ControllerBase
    {

        private LivroContext _context;
        private IMapper _mapper;
        private Livro livro = new Livro();

        public OrcamentoController(LivroContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("{id}")]
        public IActionResult AdicionaOrcamento(int id, CreateOrcamentoDto orcamentoDto)
        {
            Livro livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);
            if (livro == null)
            {
                return NotFound();
            }
            Orcamento orcamento = _mapper.Map<Orcamento>(orcamentoDto);

            orcamento.ValorPorLivro = orcamento.ValorPorPagina * livro.QtdPaginas;
            orcamento.ValorTotalLivros = orcamento.ValorPorLivro * orcamento.QtdLivros;

            orcamento.LivroId = livro.Id;

            _context.Orcamentos.Add(orcamento);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaOrcamentoPorId), new { Id = orcamento.Id }, orcamento);

        }

        [HttpGet]
        public IEnumerable<Orcamento> RecuperaOrcamento()
        {
            return _context.Orcamentos;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaOrcamentoPorId(int id)
        {
            Orcamento orcamento = _context.Orcamentos.FirstOrDefault(orcamento => orcamento.Id == id);
            if (orcamento != null)
            {
                ReadOrcamentoDto orcamentoDto = _mapper.Map<ReadOrcamentoDto>(orcamento);
                return Ok(orcamentoDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaOrcamento(int id, [FromBody] UpdateOrcamentoDto orcamentoDto)
        {
            Orcamento orcamento = _context.Orcamentos.FirstOrDefault(orcamento => orcamento.Id == id);
            if (orcamento == null)
            {
                return NotFound();
            }

            orcamento.ValorPorLivro = orcamento.ValorPorPagina * livro.QtdPaginas;
            orcamento.ValorTotalLivros = orcamento.ValorPorLivro * orcamento.QtdLivros;

            _mapper.Map(orcamentoDto, orcamento);

            orcamento.LivroId = livro.Id;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaOrcamento(int id)
        {
            Orcamento orcamento = _context.Orcamentos.FirstOrDefault(orcamento => orcamento.Id == id);
            if (orcamento == null)
            {
                return NotFound();
            }
            _context.Remove(orcamento);
            _context.SaveChanges();
            return NoContent();
        }

        /*[HttpGet("calcula/{id}")]
        public IActionResult CalculaLivro(int id, [FromBody] CalcLivroDto livroDto)
        {
            Livro livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);
            if (livro != null)
            {
                _mapper.Map(livroDto, livro);
                livroDto.ValorPorLivro = livroDto.ValorPorPagina * livroDto.QtdPaginas;
                livroDto.ValorTotalLivros = livroDto.ValorPorLivro * livroDto.QtdLivros;
                return Ok(livroDto);
            }
            return NotFound();
        }*/
    }
}
