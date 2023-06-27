using Api.Financeiro.Data;
using Api.Financeiro.Interfaces;
using Api.Financeiro.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Financeiro.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataBaseContext _context;

        public ProdutoRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> Listar()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> SelecionarId(int id)
        {
            return await _context.Produtos.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Produto> Cadastrar(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> Alterar(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return produto;
        }  
      
    }
}
