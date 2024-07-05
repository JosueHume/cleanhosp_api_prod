using System.Collections.Generic;
using System.Threading.Tasks;
using CleanHosp.Context;
using CleanHospAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanHosp.API.Services
{
    public class LimpezaService
    {
        private readonly CleanHospContext _context;

        public LimpezaService(CleanHospContext context)
        {
            _context = context;
        }

        public async Task<List<Limpeza>> GetLimpezasAsync()
        {
            return await _context.Limpezas.ToListAsync();
        }

        public async Task<Limpeza> GetLimpezaByIdAsync(int id)
        {
            return await _context.Limpezas.FindAsync(id);
        }

        public async Task AddLimpezaAsync(Limpeza limpeza)
        {
            _context.Limpezas.Add(limpeza);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLimpezaAsync(Limpeza limpeza)
        {
            _context.Entry(limpeza).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLimpezaAsync(int id)
        {
            var limpeza = await _context.Limpezas.FindAsync(id);
            if (limpeza != null)
            {
                _context.Limpezas.Remove(limpeza);
                await _context.SaveChangesAsync();
            }
        }
    }
}
