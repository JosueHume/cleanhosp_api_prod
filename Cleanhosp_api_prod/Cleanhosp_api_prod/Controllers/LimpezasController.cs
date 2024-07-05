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
    public class LimpezasController : ControllerBase
    {
        private readonly CleanHospContext _context;

        public LimpezasController(CleanHospContext context)
        {
            _context = context;
        }

        // GET: api/Limpezas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Limpeza>>> GetLimpezas()
        {
            return await _context.Limpezas.ToListAsync();
        }

        // GET: api/Limpezas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Limpeza>> GetLimpeza(int id)
        {
            var limpeza = await _context.Limpezas.FindAsync(id);

            if (limpeza == null)
            {
                return NotFound();
            }

            return limpeza;
        }

        // POST: api/Limpezas
        [HttpPost]
        public async Task<ActionResult<Limpeza>> PostLimpeza(Limpeza limpeza)
        {
            _context.Limpezas.Add(limpeza);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLimpeza), new { id = limpeza.LimpezaId }, limpeza);
        }

        // PUT: api/Limpezas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLimpeza(int id, Limpeza limpeza)
        {
            if (id != limpeza.LimpezaId)
            {
                return BadRequest();
            }

            _context.Entry(limpeza).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LimpezaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(limpeza);
        }

        // DELETE: api/Limpezas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLimpeza(int id)
        {
            var limpeza = await _context.Limpezas.FindAsync(id);
            if (limpeza == null)
            {
                return NotFound();
            }

            _context.Limpezas.Remove(limpeza);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LimpezaExists(int id)
        {
            return _context.Limpezas.Any(e => e.LimpezaId == id);
        }
    }
}
