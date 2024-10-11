using CP2.Domain.Entities;
using CP2.Domain.Interfaces.Dtos;

namespace CP2.Domain.Interfaces
{
    public interface IVendedorApplicationService
    {
        IVendedorDto? DeletarDadosVendedor(int id);
        IEnumerable<IVendedorDto> ObterTodosVendedores();
        IVendedorDto? ObterVendedorPorId(int id);
        IVendedorDto? SalvarDadosVendedor(IVendedorDto vendedor);
        IVendedorDto? EditarDadosVendedor(int id, IVendedorDto vendedor);
    }
}
