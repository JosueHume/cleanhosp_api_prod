using System.Collections.Generic;
using System.Threading.Tasks;
using CleanHosp.Context;
using CleanHospAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanHosp.API.Services
{
    public class EquipamentoService
    {
        private readonly CleanHospContext _context;

        public EquipamentoService(CleanHospContext context)
        {
            _context = context;
        }

        public async Task<List<Equipamento>> GetEquipamentosAsync()
        {
            return await _context.Equipamentos.ToListAsync();
        }

        public async Task<Equipamento> GetEquipamentoByIdAsync(int id)
        {
            return await _context.Equipamentos.FindAsync(id);
        }

        public async Task AddEquipamentoAsync(Equipamento equipamento)
        {
            _context.Equipamentos.Add(equipamento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEquipamentoAsync(Equipamento equipamento)
        {
            _context.Entry(equipamento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEquipamentoAsync(int id)
        {
            var equipamento = await _context.Equipamentos.FindAsync(id);
            if (equipamento != null)
            {
                _context.Equipamentos.Remove(equipamento);
                await _context.SaveChangesAsync();
            }
        }
    }
}
