using CP2.Application.Dtos;
using CP2.Domain.Interfaces;
using CP2.Domain.Interfaces.Dtos;

namespace CP2.Application.Services
{
    public class VendedorApplicationService : IVendedorApplicationService
    {
        private readonly IVendedorRepository _repository;

        public VendedorApplicationService(IVendedorRepository repository)
        {
            _repository = repository;
        }
        public IVendedorDto? DeletarDadosVendedor(int id)
        {
            return _repository.DeletarDados(id)?.ToDto();
        }

        public IEnumerable<IVendedorDto> ObterTodosVendedores()
        {
            var vendedores = _repository.ObterTodos();
            return vendedores.Select(x => x.ToDto());
        }

        public IVendedorDto? ObterVendedorPorId(int id)
        {
            return _repository.ObterPorId(id)?.ToDto();
        }

        public IVendedorDto? SalvarDadosVendedor(IVendedorDto vendedor)
        {
            return _repository.Inserir(vendedor.ToEntity())?.ToDto();
        }

        public IVendedorDto? EditarDadosVendedor(int id, IVendedorDto vendedor)
        {
            return _repository.Atualizar(id, vendedor.ToEntity())?.ToDto();
        }
    }
}
