namespace Api.Financeiro.Models
{
    public class AssinaturaDto
    {
        public int Id { get; set; }
        public string ClienteRazao { get; set; }
        public string ClienteTelefone { get; set; }
        public string ProdutoDescricao { get; set; }
        public string PlanoDescricao { get; set; }
        public string FormaPagamentoDescricao { get; set; }
        public int DiaVencimento { get; set; }
        public decimal Valor { get; set; }
        public DateTime Dtcadastro { get; set; }
        public DateTime Dtcancelamento { get; set; }
        public bool Cancelado { get; set; }
    }
}
