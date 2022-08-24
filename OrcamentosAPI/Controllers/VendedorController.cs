using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrcamentosAPI.Data.Dtos.Seller;
using OrcamentosAPI.Data;
using OrcamentosAPI.Models;

namespace OrcamentosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendedorController : ControllerBase
    {
        private DbAppContext _context;
        private IMapper _mapper;

        public VendedorController(DbAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaVendedor(CreateVendedorDto vendedorDto)
        {
            Vendedor vendedor = _mapper.Map<Vendedor>(vendedorDto);

            _context.Vendedor.Add(vendedor);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaVendedorPorId), new { Id = vendedor.Id }, vendedor);

        }

        [HttpGet]
        public IEnumerable<Vendedor> RecuperaVendedor()
        {
            return _context.Vendedor;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaVendedorPorId(int id)
        {
            Vendedor vendedor = _context.Vendedor.FirstOrDefault(vendedor => vendedor.Id == id);
            if (vendedor != null)
            {
                ReadVendedorDto vendedorDto = _mapper.Map<ReadVendedorDto>(vendedor);
                return Ok(vendedorDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaVendedor(int id, [FromBody] UpdateVendedorDto vendedorDto)
        {
            Vendedor vendedor = _context.Vendedor.FirstOrDefault(vendedor => vendedor.Id == id);
            if (vendedor == null)
            {
                return NotFound();
            }
            _mapper.Map(vendedorDto, vendedor);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaVendedor(int id)
        {
            Vendedor vendedor = _context.Vendedor.FirstOrDefault(vendedor => vendedor.Id == id);
            if (vendedor == null)
            {
                return NotFound();
            }
            _context.Remove(vendedor);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
