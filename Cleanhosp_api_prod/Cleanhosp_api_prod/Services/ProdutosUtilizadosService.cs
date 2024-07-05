using System.Collections.Generic;
using System.Threading.Tasks;
using CleanHosp.Context;
using CleanHospAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanHosp.API.Services
{
    public class ProdutosUtilizadosService
    {
        private readonly CleanHospContext _context;

        public ProdutosUtilizadosService(CleanHospContext context)
        {
            _context = context;
        }

        public async Task<List<ProdutosUtilizados>> GetProdutosUtilizadosAsync()
        {
            return await _context.ProdutosUtilizados.ToListAsync();
        }

        public async Task<ProdutosUtilizados> GetProdutosUtilizadosByIdAsync(int id)
        {
            return await _context.ProdutosUtilizados.FindAsync(id);
        }

        public async Task AddProdutosUtilizadosAsync(ProdutosUtilizados produtosUtilizados)
        {
            _context.ProdutosUtilizados.Add(produtosUtilizados);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProdutosUtilizadosAsync(ProdutosUtilizados produtosUtilizados)
        {
            _context.Entry(produtosUtilizados).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProdutosUtilizadosAsync(int id)
        {
            var produtosUtilizados = await _context.ProdutosUtilizados.FindAsync(id);
            if (produtosUtilizados != null)
            {
                _context.ProdutosUtilizados.Remove(produtosUtilizados);
                await _context.SaveChangesAsync();
            }
        }
    }
}
