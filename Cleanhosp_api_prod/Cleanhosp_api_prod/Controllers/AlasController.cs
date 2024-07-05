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
    public class AlasController : ControllerBase
    {
        private readonly CleanHospContext _context;

        public AlasController(CleanHospContext context)
        {
            _context = context;
        }

        // GET: api/Alas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ala>>> GetAlas()
        {
            return await _context.Alas.ToListAsync();
        }

        // GET: api/Alas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ala>> GetAla(int id)
        {
            var ala = await _context.Alas.FindAsync(id);

            if (ala == null)
            {
                return NotFound();
            }

            return ala;
        }

        // POST: api/Alas
        [HttpPost]
        public async Task<ActionResult<Ala>> PostAla(Ala ala)
        {
            _context.Alas.Add(ala);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAla), new { id = ala.AlaId }, ala);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAla(int id, Ala ala)
        {
            if (id != ala.AlaId)
            {
                return BadRequest();
            }

            _context.Entry(ala).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(ala);
        }


        // DELETE: api/Alas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAla(int id)
        {
            var ala = await _context.Alas.FindAsync(id);
            if (ala == null)
            {
                return NotFound();
            }

            _context.Alas.Remove(ala);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool AlaExists(int id)
        {
            return _context.Alas.Any(e => e.AlaId == id);
        }
    }
}
