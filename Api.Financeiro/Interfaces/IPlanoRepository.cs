using Api.Financeiro.Models;

namespace Api.Financeiro.Interfaces
{
    public interface IPlanoRepository
    {
        Task<IEnumerable<Plano>> Listar();
        Task<Plano> SelecionarId(int id);
        Task<Plano> Cadastrar(Plano plano);
        Task<Plano> Alterar(Plano plano);
    }
}
