using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using OrcamentosAPI.Data;
using OrcamentosAPI.Data.Dtos.Product;
using OrcamentosAPI.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OrcamentosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private DbAppContext _context;
        private IMapper _mapper;

        public ProdutoController(DbAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaProduto(CreateProdutoDto produtoDto)
        {
            Produto produto = _mapper.Map<Produto>(produtoDto);

            _context.Produto.Add(produto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaProdutoPorId), new { Id = produto.Id }, produto);

        }

        [HttpGet]
        public IEnumerable<Produto> RecuperaProduto()
        {
            return _context.Produto;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaProdutoPorId(int id)
        {
            Produto produto = _context.Produto.FirstOrDefault(produto => produto.Id == id);
            if (produto != null)
            {
                ReadProdutoDto produtoDto = _mapper.Map<ReadProdutoDto>(produto);
                return Ok(produtoDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaProduto(int id, [FromBody] UpdateProdutoDto produtoDto)
        {
            Produto produto = _context.Produto.FirstOrDefault(produto => produto.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            _mapper.Map(produtoDto, produto);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaProduto(int id)
        {
            Produto produto = _context.Produto.FirstOrDefault(produto => produto.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            _context.Remove(produto);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
