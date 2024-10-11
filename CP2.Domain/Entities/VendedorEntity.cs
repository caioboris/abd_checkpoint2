using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP2.Domain.Entities
{
    [Table("tb_vendedor")]
    public class VendedorEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [MaxLength(300)]
        public string Endereco { get; set; } = string.Empty;

        [Required]
        [MaxLength(11)]
        public string Telefone { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        public DateTime DataContratacao { get; set; }

        [Required]
        public decimal ComissaoPercentual { get; set; }

        [Required]
        public decimal MetaMensal { get; set; }

        [Required]
        public DateTime CriadoEm { get; set; }
    }
}
