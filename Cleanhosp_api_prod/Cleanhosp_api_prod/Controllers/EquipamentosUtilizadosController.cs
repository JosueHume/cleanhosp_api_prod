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
    public class EquipamentosUtilizadosController : ControllerBase
    {
        private readonly CleanHospContext _context;

        public EquipamentosUtilizadosController(CleanHospContext context)
        {
            _context = context;
        }

        // GET: api/EquipamentosUtilizados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipamentosUtilizados>>> GetEquipamentosUtilizados()
        {
            return await _context.EquipamentosUtilizados.ToListAsync();
        }

        // GET: api/EquipamentosUtilizados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipamentosUtilizados>> GetEquipamentosUtilizados(int id)
        {
            var equipamentosUtilizados = await _context.EquipamentosUtilizados.FindAsync(id);

            if (equipamentosUtilizados == null)
            {
                return NotFound();
            }

            return equipamentosUtilizados;
        }

        // POST: api/EquipamentosUtilizados
        [HttpPost]
        public async Task<ActionResult<EquipamentosUtilizados>> PostEquipamentosUtilizados(EquipamentosUtilizados equipamentosUtilizados)
        {
            _context.EquipamentosUtilizados.Add(equipamentosUtilizados);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEquipamentosUtilizados), new { id = equipamentosUtilizados.EquipamentosUtilizadosId }, equipamentosUtilizados);
        }

        // PUT: api/EquipamentosUtilizados/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipamentosUtilizados(int id, EquipamentosUtilizados equipamentosUtilizados)
        {
            if (id != equipamentosUtilizados.EquipamentosUtilizadosId)
            {
                return BadRequest();
            }

            _context.Entry(equipamentosUtilizados).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipamentosUtilizadosExists(id))
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

        // DELETE: api/EquipamentosUtilizados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipamentosUtilizados(int id)
        {
            var equipamentosUtilizados = await _context.EquipamentosUtilizados.FindAsync(id);
            if (equipamentosUtilizados == null)
            {
                return NotFound();
            }

            _context.EquipamentosUtilizados.Remove(equipamentosUtilizados);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipamentosUtilizadosExists(int id)
        {
            return _context.EquipamentosUtilizados.Any(e => e.EquipamentosUtilizadosId == id);
        }
    }
}
