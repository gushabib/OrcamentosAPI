using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrcamentosAPI.Data;
using OrcamentosAPI.Data.Dtos.Budget;
using OrcamentosAPI.Data.Dtos.Product;
using OrcamentosAPI.Models;

namespace OrcamentosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrcamentoController : ControllerBase
    {

        private DbAppContext _context;
        private IMapper _mapper;

        public OrcamentoController(DbAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaOrcamento(CreateOrcamentoDto orcamentoDto)
        {            
            Orcamento orcamento = _mapper.Map<Orcamento>(orcamentoDto);
            Produto produto = _context.Produto.FirstOrDefault(produto => produto.Id == orcamento.ProdutoId);
            Vendedor vendedor = _context.Vendedor.FirstOrDefault(vendedor => vendedor.Id == orcamento.VendedorId);

            orcamento.ValorTotalProdutos = orcamento.QtdProdutos * produto.Valor;
            orcamento.ValorDaComissao = orcamento.ValorTotalProdutos * vendedor.Comissao;

            _context.Orcamentos.Add(orcamento);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaOrcamento), new { Id = orcamento.Id }, orcamento);

        }

        [HttpGet]
        public IActionResult RecuperaOrcamento([FromQuery] int? id = null)
        {
            List<Orcamento> orcamento;
            if (id == null)
            {
                orcamento = _context.Orcamentos.ToList();
            }
            else
            {
                orcamento = _context
                .Orcamentos.Where(orcamento => orcamento.Id == id).ToList();
            }
            if (orcamento != null)
            {
                List<ReadOrcamentoDto> orcamentoDto = _mapper.Map<List<ReadOrcamentoDto>>(orcamento);
                return Ok(orcamentoDto);
            }
            return NotFound();
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
    }
}
