using System.Collections.Generic;
using System.Threading.Tasks;
using CleanHosp.Context;
using CleanHospAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanHosp.API.Services
{
    public class LocalService
    {
        private readonly CleanHospContext _context;

        public LocalService(CleanHospContext context)
        {
            _context = context;
        }

        public async Task<List<Local>> GetLocaisAsync()
        {
            return await _context.Locais.ToListAsync();
        }

        public async Task<Local> GetLocalByIdAsync(int id)
        {
            return await _context.Locais.FindAsync(id);
        }

        public async Task AddLocalAsync(Local local)
        {
            _context.Locais.Add(local);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLocalAsync(Local local)
        {
            _context.Entry(local).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLocalAsync(int id)
        {
            var local = await _context.Locais.FindAsync(id);
            if (local != null)
            {
                _context.Locais.Remove(local);
                await _context.SaveChangesAsync();
            }
        }
    }
}
