using CP2.Domain.Interfaces.Dtos;

namespace CP2.Domain.Interfaces
{
    public interface IFornecedorApplicationService
    {
        IFornecedorDto? DeletarDadosFornecedor(int id);
        IEnumerable<IFornecedorDto> ObterTodosFornecedores();
        IFornecedorDto? ObterFornecedorPorId(int id);
        IFornecedorDto? SalvarDadosFornecedor(IFornecedorDto vendedor);
        IFornecedorDto? EditarDadosFornecedor(int id, IFornecedorDto vendedor);
    }
}
