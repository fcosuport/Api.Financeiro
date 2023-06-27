using Api.Financeiro.Data;
using Api.Financeiro.Interfaces;
using Api.Financeiro.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Api.Financeiro.Repositories
{
    public class FormaPagamentoRepository : IFormaPagamentoRepository
    {
        private readonly DataBaseContext _context;

        public FormaPagamentoRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FormaPagamento>> Listar()
        {
            return await _context.Formapagamentos.ToListAsync();
        }

        public async Task<FormaPagamento> SelecionarId(int id)
        {
            return await _context.Formapagamentos.Where(f => f.Id == id).FirstOrDefaultAsync();
        }

        public async Task<FormaPagamento> Cadastrar(FormaPagamento formaPagamento)
        {
            _context.Formapagamentos.Add(formaPagamento);
            await _context.SaveChangesAsync();
            return formaPagamento;
        }

        public async Task<FormaPagamento> Alterar(FormaPagamento formaPagamento)
        {
            _context.Entry(formaPagamento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return formaPagamento;
        }

    }
}
