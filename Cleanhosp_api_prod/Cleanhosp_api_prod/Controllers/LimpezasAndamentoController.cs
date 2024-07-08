using CleanHosp.Context;
using CleanHospAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<IEnumerable<LimpezaAndamento>>> GetLimpezasAndamento()
        {
            return await _context.LimpezasAndamento.ToListAsync();
        }

        // GET: api/LimpezasAndamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LimpezaAndamento>> GetLimpezaAndamento(int id)
        {
            var limpezaAndamento = await _context.LimpezasAndamento.FindAsync(id);

            if (limpezaAndamento == null)
            {
                return NotFound();
            }

            return limpezaAndamento;
        }

        [HttpPost]
        public async Task<ActionResult<LimpezaAndamento>> PostLimpezaAndamento(LimpezaAndamento limpezaAndamento)
        {
            limpezaAndamento.DataInicio = limpezaAndamento.DataInicio?.ToUniversalTime();
            limpezaAndamento.DataFim = DateTime.UtcNow;

            _context.LimpezasAndamento.Add(limpezaAndamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLimpezaAndamento), new { id = limpezaAndamento.LimpezaAndamentoId }, limpezaAndamento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLimpezaAndamento(int id, [FromBody] LimpezaAndamento limpezaAndamento)
        {
            if (id != limpezaAndamento.LimpezaAndamentoId)
            {
                return BadRequest();
            }

            // Atribui os novos valores recebidos
            limpezaAndamento.Finalizado = true;
            limpezaAndamento.DataFim = DateTime.UtcNow;

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

            return Ok(limpezaAndamento);
        }


        // DELETE: api/LimpezasAndamento/5
        [HttpDelete("{id}")]
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
