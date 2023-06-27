using Api.Financeiro.Models;

namespace Api.Financeiro.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> Listar();
        Task<Produto> SelecionarId(int id);
        Task<Produto> Cadastrar(Produto produto);
        Task<Produto> Alterar(Produto produto);
    }
}
