using System.Collections.Generic;
using System.Threading.Tasks;
using CleanHosp.Context;
using CleanHospAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanHosp.API.Services
{
    public class PessoaService
    {
        private readonly CleanHospContext _context;

        public PessoaService(CleanHospContext context)
        {
            _context = context;
        }

        public async Task<List<Pessoa>> GetPessoasAsync()
        {
            return await _context.Pessoas.ToListAsync();
        }

        public async Task<Pessoa> GetPessoaByIdAsync(int id)
        {
            return await _context.Pessoas.FindAsync(id);
        }

        public async Task AddPessoaAsync(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePessoaAsync(Pessoa pessoa)
        {
            _context.Entry(pessoa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePessoaAsync(int id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            if (pessoa != null)
            {
                _context.Pessoas.Remove(pessoa);
                await _context.SaveChangesAsync();
            }
        }
    }
}
