using CP2.Domain.Entities;
using CP2.Domain.Interfaces.Dtos;
using FluentValidation;

namespace CP2.Application.Dtos
{
    public class FornecedorDto : IFornecedorDto
    {
        public DateTime CriadoEm { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CNPJ { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public void Validate()
        {
            var validateResult = new FornecedorDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class FornecedorDtoValidation : AbstractValidator<FornecedorDto>
    {
        public FornecedorDtoValidation()
        {
            RuleFor(x => x.Nome)
                .MinimumLength(5).WithMessage($"o Campo {nameof(FornecedorDto.Nome)} deve ter no mínimo 5 caracteres.")
                .NotEmpty().WithMessage($"o Campo {nameof(FornecedorDto.Nome)} não pode ser vazio.");

            RuleFor(x => x.Endereco)
                .MinimumLength(5).WithMessage($"o Campo {nameof(FornecedorDto.Endereco)} deve ter no mínimo 5 caracteres.")
                .NotEmpty().WithMessage($"o Campo {nameof(FornecedorDto.Endereco)} não pode ser vazio.");

            RuleFor(x => x.CNPJ)
                .MinimumLength(14).WithMessage($"o Campo {nameof(FornecedorDto.CNPJ)} é inválido.")
                .MaximumLength(14).WithMessage($"o Campo {nameof(FornecedorDto.CNPJ)} é inválido.")
                .NotEmpty().WithMessage($"o Campo {nameof(FornecedorDto.CNPJ)} não pode ser vazio.");

            RuleFor(x => x.Telefone)
                .MinimumLength(11).WithMessage($"o Campo {nameof(FornecedorDto.Telefone)} é inválido.")
                .MaximumLength(11).WithMessage($"o Campo {nameof(FornecedorDto.Telefone)} é inválido.")
                .NotEmpty().WithMessage($"o Campo {nameof(FornecedorDto.Telefone)} não pode ser vazio.");

            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty().WithMessage($"o Campo {nameof(FornecedorDto.Email)} não pode ser vazio.");
        }
    }

    internal static class FornecedorMapper
    {
        public static IFornecedorDto ToDto(this FornecedorEntity entity)
        {
            return new FornecedorDto
            {
                Nome = entity.Nome,
                CNPJ = entity.CNPJ,
                CriadoEm = entity.CriadoEm,
                Email = entity.Email,
                Endereco = entity.Endereco,
                Id = entity.Id,
                Telefone = entity.Telefone,
            };
        }

        public static FornecedorEntity ToEntity(this IFornecedorDto dto)
        {
            return new FornecedorEntity
            {
                Nome = dto.Nome,
                CNPJ = dto.CNPJ,
                CriadoEm = dto.CriadoEm,
                Email = dto.Email,
                Endereco = dto.Endereco,
                Id = dto.Id,
                Telefone = dto.Telefone,
            };
        }
    }
}
