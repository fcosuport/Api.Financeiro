using Api.Financeiro.Models;

namespace Api.Financeiro.Interfaces
{
    public interface IAssinaturaRepository
    {
        Task<IEnumerable<AssinaturaDto>> Selecionar(string cliente, int produto, int plano, int formapagamento, string status);
        Task<Assinatura> SelecionarId(int id);
        Task<Assinatura> Cadastrar(Assinatura assinatura);
        Task<Assinatura> Alterar(int id, Assinatura assinatura);
        Task<Assinatura> Cancelar(int id);
    }
}
