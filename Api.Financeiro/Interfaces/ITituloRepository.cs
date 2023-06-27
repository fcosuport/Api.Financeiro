using Api.Financeiro.Models;

namespace Api.Financeiro.Interfaces
{
    public interface ITituloRepository
    {
        Task<IEnumerable<TituloDto>> Selecionar(int cliente, int formapagamento, int numparcela, string status, string opcaodata, DateTime datainicial, DateTime datafinal, string ordenar);
        Task<Titulo> SelecionarId(int id);
        Task<Titulo> Cadastrar(Titulo titulo);
        Task<Titulo> Alterar(int id, Titulo titulo);
        Task<Titulo> Cancelar(int id);
    }
}
