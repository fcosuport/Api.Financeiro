using Api.Financeiro.Data;
using Api.Financeiro.Interfaces;
using Api.Financeiro.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Financeiro.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataBaseContext _context;

        public ClienteRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> Listar()
        {
            return await _context.Clientes.OrderByDescending(c => c.Id).ToListAsync();
        }

        public async Task<Cliente> SelecionarId(int id)
        {
            return await _context.Clientes.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Cliente> Cadastrar(Cliente cliente)
        {
            cliente.Dtcadastro = DateTime.Now;
            cliente.Dtalteracao = DateTime.Now;
            cliente.Inativo = false;

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> Alterar(int id, Cliente cliente)
        {
            cliente.Dtalteracao = DateTime.Now;

            _context.Entry(cliente).State = EntityState.Modified;
            _context.Entry(cliente).Property(c => c.Dtcadastro).IsModified = false;
            await _context.SaveChangesAsync();
            return cliente;
        }

    }
}
