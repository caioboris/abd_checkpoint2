using CP2.Domain.Entities;

namespace CP2.Domain.Interfaces
{
    public interface IVendedorRepository
    {
        VendedorEntity? ObterPorId(int id);
        IEnumerable<VendedorEntity> ObterTodos();
        VendedorEntity? DeletarDados(int id);
        VendedorEntity? Inserir(VendedorEntity entity);
        VendedorEntity? Atualizar(int id, VendedorEntity entity);
    }
}
