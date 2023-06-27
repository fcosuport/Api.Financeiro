using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Financeiro.Models
{
    public class Titulo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        [Required]
        public int FormaPagamentoId { get; set; }
        public FormaPagamento? FormaPagamento { get; set; }

        [Column(TypeName = "numeric(10,2)")]
        public decimal Valor { get; set; }

        [StringLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string Status { get; set; } = string.Empty;

        [Required]
        public int NumParcela { get; set; }

        [Required]
        public int QtdeParcelas { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Emissao { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Vencimento { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DtPagamento { get; set; }

        [Column(TypeName = "Boolean")]
        public Boolean Cancelado { get; set; }
    }
}
