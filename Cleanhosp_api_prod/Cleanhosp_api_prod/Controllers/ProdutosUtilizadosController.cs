using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanHospAPI.Models;
using CleanHosp.Context;

namespace CleanHospAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosUtilizadosController : ControllerBase
    {
        private readonly CleanHospContext _context;

        public ProdutosUtilizadosController(CleanHospContext context)
        {
            _context = context;
        }

        // GET: api/ProdutosUtilizados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutosUtilizados>>> GetProdutosUtilizados()
        {
            return await _context.ProdutosUtilizados.ToListAsync();
        }

        // GET: api/ProdutosUtilizados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutosUtilizados>> GetProdutosUtilizados(int id)
        {
            var produtosUtilizados = await _context.ProdutosUtilizados.FindAsync(id);

            if (produtosUtilizados == null)
            {
                return NotFound();
            }

            return produtosUtilizados;
        }

        // POST: api/ProdutosUtilizados
        [HttpPost]
        public async Task<ActionResult<ProdutosUtilizados>> PostProdutosUtilizados(ProdutosUtilizados produtosUtilizados)
        {
            _context.ProdutosUtilizados.Add(produtosUtilizados);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProdutosUtilizados), new { id = produtosUtilizados.ProdutosUtilizadosId }, produtosUtilizados);
        }

        // PUT: api/ProdutosUtilizados/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdutosUtilizados(int id, ProdutosUtilizados produtosUtilizados)
        {
            if (id != produtosUtilizados.ProdutosUtilizadosId)
            {
                return BadRequest();
            }

            _context.Entry(produtosUtilizados).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutosUtilizadosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/ProdutosUtilizados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdutosUtilizados(int id)
        {
            var produtosUtilizados = await _context.ProdutosUtilizados.FindAsync(id);
            if (produtosUtilizados == null)
            {
                return NotFound();
            }

            _context.ProdutosUtilizados.Remove(produtosUtilizados);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutosUtilizadosExists(int id)
        {
            return _context.ProdutosUtilizados.Any(e => e.ProdutosUtilizadosId == id);
        }
    }
}
