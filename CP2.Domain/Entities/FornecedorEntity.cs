using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP2.Domain.Entities
{
    [Table("tb_fornecedor")]
    public class FornecedorEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [MaxLength(14)]
        public string CNPJ { get; set; } = string.Empty;

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
        public DateTime CriadoEm { get; set; } 
    }
}
