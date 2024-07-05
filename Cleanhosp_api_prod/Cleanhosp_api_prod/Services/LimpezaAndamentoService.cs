using System.Collections.Generic;
using System.Threading.Tasks;
using CleanHosp.Context;
using CleanHospAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanHosp.API.Services
{
    public class LimpezaAndamentoService
    {
        private readonly CleanHospContext _context;

        public LimpezaAndamentoService(CleanHospContext context)
        {
            _context = context;
        }

        public async Task<List<LimpezaAndamento>> GetLimpezasAndamentoAsync()
        {
            return await _context.LimpezasAndamento.ToListAsync();
        }

        public async Task<LimpezaAndamento> GetLimpezaAndamentoByIdAsync(int id)
        {
            return await _context.LimpezasAndamento.FindAsync(id);
        }

        public async Task AddLimpezaAndamentoAsync(LimpezaAndamento limpezaAndamento)
        {
            _context.LimpezasAndamento.Add(limpezaAndamento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLimpezaAndamentoAsync(LimpezaAndamento limpezaAndamento)
        {
            _context.Entry(limpezaAndamento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLimpezaAndamentoAsync(int id)
        {
            var limpezaAndamento = await _context.LimpezasAndamento.FindAsync(id);
            if (limpezaAndamento != null)
            {
                _context.LimpezasAndamento.Remove(limpezaAndamento);
                await _context.SaveChangesAsync();
            }
        }
    }
}
