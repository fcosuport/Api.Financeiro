using Api.Financeiro.Models;

namespace Api.Financeiro.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> Listar();
        Task<Cliente> SelecionarId(int id);
        Task<Cliente> Cadastrar(Cliente cliente);
        Task<Cliente> Alterar(int id,Cliente cliente);
    }
}
