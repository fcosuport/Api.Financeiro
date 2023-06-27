using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Financeiro.Models
{
    public class Plano
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [Column(TypeName = "varchar(30)")]
        public string Descricao { get; set; } = string.Empty;

        public ICollection<Assinatura>? Assinaturas { get; }
    }
}
