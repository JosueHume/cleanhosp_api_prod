using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanHospAPI.Models;
using CleanHosp.Context;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace CleanHospAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LimpezasAndamentoController : ControllerBase
    {
        private readonly CleanHospContext _context;

        public LimpezasAndamentoController(CleanHospContext context)
        {
            _context = context;
        }

        // GET: api/LimpezasAndamento
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<LimpezaAndamento>>> GetLimpezasAndamento()
        {
            return await _context.LimpezasAndamento.ToListAsync();
        }

        // GET: api/LimpezasAndamento/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<LimpezaAndamento>> GetLimpezaAndamento(int id)
        {
            var limpezaAndamento = await _context.LimpezasAndamento.FindAsync(id);

            if (limpezaAndamento == null)
            {
                return NotFound();
            }

            return limpezaAndamento;
        }

        // POST: api/LimpezasAndamento
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<LimpezaAndamento>> PostLimpezaAndamento(LimpezaAndamento limpezaAndamento)
        {
            _context.LimpezasAndamento.Add(limpezaAndamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLimpezaAndamento), new { id = limpezaAndamento.LimpezaAndamentoId }, limpezaAndamento);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutLimpezaAndamento(int id, LimpezaAndamento limpezaAndamento)
        {
            if (id != limpezaAndamento.LimpezaAndamentoId)
            {
                return BadRequest();
            }

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var existingLimpeza = await _context.LimpezasAndamento.FindAsync(id);

            if (existingLimpeza == null || existingLimpeza.PessoaId.ToString() != userId)
            {
                return Forbid();
            }

            _context.Entry(limpezaAndamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LimpezaAndamentoExists(id))
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

        // DELETE: api/LimpezasAndamento/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteLimpezaAndamento(int id)
        {
            var limpezaAndamento = await _context.LimpezasAndamento.FindAsync(id);
            if (limpezaAndamento == null)
            {
                return NotFound();
            }

            _context.LimpezasAndamento.Remove(limpezaAndamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LimpezaAndamentoExists(int id)
        {
            return _context.LimpezasAndamento.Any(e => e.LimpezaAndamentoId == id);
        }
    }
}
