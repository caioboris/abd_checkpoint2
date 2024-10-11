using CP2.Domain.Entities;
using CP2.Domain.Interfaces.Dtos;
using FluentValidation;

namespace CP2.Application.Dtos
{
    public class VendedorDto : IVendedorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public DateTime DataContratacao { get; set; }
        public decimal ComissaoPercentual { get; set; }
        public decimal MetaMensal { get; set; }
        public DateTime CriadoEm { get; set; }

        public void Validate()
        {
            var validateResult = new VendedorDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class VendedorDtoValidation : AbstractValidator<VendedorDto>
    {
        public VendedorDtoValidation()
        {
            RuleFor(x => x.Nome)
               .MinimumLength(5).WithMessage($"o Campo {nameof(VendedorDto.Nome)} deve ter no mínimo 5 caracteres.")
               .NotEmpty().WithMessage($"o Campo {nameof(VendedorDto.Nome)} não pode ser vazio.");

            RuleFor(x => x.Endereco)
                .MinimumLength(5).WithMessage($"o Campo {nameof(VendedorDto.Endereco)} deve ter no mínimo 5 caracteres.")
                .NotEmpty().WithMessage($"o Campo {nameof(VendedorDto.Endereco)} não pode ser vazio.");

            RuleFor(x => x.MetaMensal)
                .GreaterThan(0).WithMessage($"o Campo {nameof(VendedorDto.MetaMensal)} deve ter ser maior do que 0.");

            RuleFor(x => x.ComissaoPercentual)
                .GreaterThan(0).WithMessage($"o Campo {nameof(VendedorDto.ComissaoPercentual)} deve ter ser maior do que 0.");

            RuleFor(x => x.Telefone)
                .MinimumLength(11).WithMessage($"o Campo {nameof(VendedorDto.Telefone)} é inválido.")
                .MaximumLength(11).WithMessage($"o Campo {nameof(VendedorDto.Telefone)} é inválido.")
                .NotEmpty().WithMessage($"o Campo {nameof(VendedorDto.Telefone)} não pode ser vazio.");

            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty().WithMessage($"o Campo {nameof(VendedorDto.Email)} não pode ser vazio.");
        }
    }

    internal static class VendedorMapper
    {
        public static IVendedorDto ToDto(this VendedorEntity entity)
        {
            return new VendedorDto
            {
                Nome = entity.Nome,
                Endereco = entity.Endereco,
                ComissaoPercentual = entity.ComissaoPercentual,
                Telefone = entity.Telefone,
                CriadoEm = entity.CriadoEm,
                DataContratacao = entity.DataContratacao,
                DataNascimento = entity.DataNascimento,
                Email = entity.Email,
                Id = entity.Id,
                MetaMensal = entity.MetaMensal,
            };
        }

        public static VendedorEntity ToEntity(this IVendedorDto dto)
        {
            return new VendedorEntity
            {
                Nome = dto.Nome,
                Endereco = dto.Endereco,
                ComissaoPercentual = dto.ComissaoPercentual,
                Telefone = dto.Telefone,
                CriadoEm = dto.CriadoEm,
                DataContratacao = dto.DataContratacao,
                DataNascimento = dto.DataNascimento,
                Email = dto.Email,
                Id = dto.Id,
                MetaMensal = dto.MetaMensal,
            };
        }

    }
}
