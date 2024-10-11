using CP2.Application.Dtos;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using CP2.Domain.Interfaces.Dtos;

namespace CP2.Application.Services
{
    public class FornecedorApplicationService : IFornecedorApplicationService
    {
        private readonly IFornecedorRepository _repository;

        public FornecedorApplicationService(IFornecedorRepository repository)
        {
            _repository = repository;
        }

        public IFornecedorDto? DeletarDadosFornecedor(int id)
        {
            return _repository.DeletarDados(id)?.ToDto();
        }

        public IEnumerable<IFornecedorDto> ObterTodosFornecedores()
        {
            var vendedores = _repository.ObterTodos();
            return vendedores.Select(x => x.ToDto());
        }

        public IFornecedorDto? ObterFornecedorPorId(int id)
        {
            return _repository.ObterPorId(id)?.ToDto();
        }

        public IFornecedorDto? SalvarDadosFornecedor(IFornecedorDto vendedor)
        {
            return _repository.Inserir(vendedor.ToEntity())?.ToDto();
        }

        public IFornecedorDto? EditarDadosFornecedor(int id, IFornecedorDto vendedor)
        {
            return _repository.Atualizar(id, vendedor.ToEntity())?.ToDto();
        }

    }
}
