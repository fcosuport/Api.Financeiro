using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Financeiro.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Descricao { get; set; } = string.Empty;

        [Column(TypeName = "numeric(10,2)")]
        public decimal Valor { get; set; }

        [StringLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string CodProdGn { get; set; } = string.Empty;

        public ICollection<Assinatura>? Assinaturas { get; }
    }
}
