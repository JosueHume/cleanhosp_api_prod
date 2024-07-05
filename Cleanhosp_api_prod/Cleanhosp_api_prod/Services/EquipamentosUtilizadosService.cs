using System.Collections.Generic;
using System.Threading.Tasks;
using CleanHosp.Context;
using CleanHospAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanHosp.API.Services
{
    public class EquipamentosUtilizadosService
    {
        private readonly CleanHospContext _context;

        public EquipamentosUtilizadosService(CleanHospContext context)
        {
            _context = context;
        }

        public async Task<List<EquipamentosUtilizados>> GetEquipamentosUtilizadosAsync()
        {
            return await _context.EquipamentosUtilizados.ToListAsync();
        }

        public async Task<EquipamentosUtilizados> GetEquipamentosUtilizadosByIdAsync(int id)
        {
            return await _context.EquipamentosUtilizados.FindAsync(id);
        }

        public async Task AddEquipamentosUtilizadosAsync(EquipamentosUtilizados equipamentosUtilizados)
        {
            _context.EquipamentosUtilizados.Add(equipamentosUtilizados);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEquipamentosUtilizadosAsync(EquipamentosUtilizados equipamentosUtilizados)
        {
            _context.Entry(equipamentosUtilizados).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEquipamentosUtilizadosAsync(int id)
        {
            var equipamentosUtilizados = await _context.EquipamentosUtilizados.FindAsync(id);
            if (equipamentosUtilizados != null)
            {
                _context.EquipamentosUtilizados.Remove(equipamentosUtilizados);
                await _context.SaveChangesAsync();
            }
        }
    }
}
