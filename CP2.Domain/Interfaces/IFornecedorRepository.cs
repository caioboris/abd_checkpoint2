using CP2.Domain.Entities;

namespace CP2.Domain.Interfaces
{
    public interface IFornecedorRepository
    {
        FornecedorEntity? ObterPorId(int id);
        IEnumerable<FornecedorEntity> ObterTodos();
        FornecedorEntity? DeletarDados(int id);
        FornecedorEntity? Inserir(FornecedorEntity entity);
        FornecedorEntity? Atualizar(int id, FornecedorEntity entity);
    }
}
