using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Financeiro.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Razao { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Fantasia { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string Cnpj_Cpf { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        [Column(TypeName = "varchar(20)")]
        public string Telefone { get; set; } = string.Empty;

        [StringLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; } = string.Empty;

        [StringLength(200)]
        [Column(TypeName = "varchar(200)")]
        public string Obs { get; set; } = string.Empty;

        [Column(TypeName = "Boolean")]
        public Boolean Inativo { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Dtcadastro { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Dtalteracao { get; set; }

        public ICollection<Assinatura>? Assinaturas { get; }

        public ICollection<Titulo>? Titulos { get; }
    }
}
