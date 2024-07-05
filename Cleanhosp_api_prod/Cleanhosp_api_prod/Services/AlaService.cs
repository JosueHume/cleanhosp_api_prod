using CleanHosp.Context;
using CleanHospAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanHosp.API.Services
{
    public class AlaService
    {
        private readonly CleanHospContext _context;

        public AlaService(CleanHospContext context)
        {
            _context = context;
        }

        // Métodos de exemplo para CRUD

        public async Task<List<Ala>> GetAlasAsync()
        {
            return await _context.Alas.ToListAsync();
        }

        public async Task<Ala> GetAlaByIdAsync(int id)
        {
            return await _context.Alas.FindAsync(id);
        }

        public async Task AddAlaAsync(Ala ala)
        {
            _context.Alas.Add(ala);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAlaAsync(Ala ala)
        {
            _context.Entry(ala).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAlaAsync(int id)
        {
            var ala = await _context.Alas.FindAsync(id);
            if (ala != null)
            {
                _context.Alas.Remove(ala);
                await _context.SaveChangesAsync();
            }
        }
    }
}
