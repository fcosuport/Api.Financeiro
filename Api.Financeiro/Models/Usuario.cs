using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Financeiro.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [Column(TypeName = "varchar(30)")]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [StringLength(6)]
        [Column(TypeName = "varchar(6)")]
        public string Senha { get; set; } = string.Empty;
    }
}
