using System.ComponentModel.DataAnnotations;

namespace CP2.Domain.Interfaces.Dtos
{
    public interface IVendedorDto
    {
        int Id { get; set; }
        string Nome { get; set; }
        string Endereco { get; set; }
        string Telefone { get; set; }
        string Email { get; set; }
        DateTime DataNascimento { get; set; }
        DateTime DataContratacao { get; set; }
        decimal ComissaoPercentual { get; set; }
        decimal MetaMensal { get; set; }
        DateTime CriadoEm { get; set; }
        void Validate();
    }
}
