using Api.Financeiro.Models;

namespace Api.Financeiro.Interfaces
{
    public interface IFormaPagamentoRepository
    {
        Task<IEnumerable<FormaPagamento>> Listar();
        Task<FormaPagamento> SelecionarId(int id);
        Task<FormaPagamento> Cadastrar(FormaPagamento formaPagamento);
        Task<FormaPagamento> Alterar(FormaPagamento formaPagamento);
    }
}
