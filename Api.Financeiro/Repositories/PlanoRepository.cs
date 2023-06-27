using Api.Financeiro.Data;
using Api.Financeiro.Interfaces;
using Api.Financeiro.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Financeiro.Repositories
{
    public class PlanoRepository : IPlanoRepository
    {
        private readonly DataBaseContext _context;

        public PlanoRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Plano>> Listar()
        {
            return await _context.Planos.ToListAsync();
        }

        public async Task<Plano> SelecionarId(int id)
        {
            return await _context.Planos.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Plano> Cadastrar(Plano plano)
        {
            _context.Planos.Add(plano);
            await _context.SaveChangesAsync();
            return plano;
        }        

        public async Task<Plano> Alterar(Plano plano)
        {
            _context.Entry(plano).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return plano;
        }

    }
}
