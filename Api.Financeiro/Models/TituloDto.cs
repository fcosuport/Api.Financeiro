namespace Api.Financeiro.Models
{
    public class TituloDto
    {
        public int Id { get; set; }
        public string ClienteRazao { get; set; }
        public string FormaPagamentoDescricao { get; set; }
        public decimal Valor { get; set; }
        public string Status { get; set; }
        public int NumParcela { get; set; }
        public DateTime Emissao { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime DtPagamento { get; set; }
    }
}
