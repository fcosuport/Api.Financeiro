using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Financeiro.Models
{
    public class Assinatura
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        [Required]
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }

        [Required]
        public int PlanoId { get; set; }
        public Plano? Plano { get; set; }

        [Required]
        public int FormaPagamentoId { get; set; }
        public FormaPagamento? FormaPagamento { get; set; }

        public int DiaVencimento { get; set; }

        [Column(TypeName = "numeric(10,2)")]
        public decimal Valor { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Dtcadastro { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Dtcancelamento { get; set; }

        [Column(TypeName = "Boolean")]
        public Boolean Cancelado { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DtPrimeiraParcela { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string CodAssinatura { get; set; } = string.Empty;

        [StringLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string NomeWhats { get; set; } = string.Empty;
    }
}
