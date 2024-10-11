using CP2.Data.AppData;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;

namespace CP2.Data.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApplicationContext _context;

        public FornecedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public FornecedorEntity? DeletarDados(int id)
        {
            var fornecedor = _context.Fornecedor.Find(id);
            if (fornecedor != null)
            {
                _context.Remove(fornecedor);
                _context.SaveChanges();
            }

            return fornecedor;
        }

        public IEnumerable<FornecedorEntity> ObterTodos()
        {
            return _context.Fornecedor.ToList();
        }

        public FornecedorEntity? ObterPorId(int id)
        {
            return _context.Fornecedor.FirstOrDefault(x => x.Id == id);
        }

        public FornecedorEntity? Inserir(FornecedorEntity entity)
        {
            _context.Fornecedor.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public FornecedorEntity? Atualizar(int id, FornecedorEntity entity)
        {
            var fornecedor = _context.Fornecedor.Find(id);

            if (fornecedor != null)
            {
                fornecedor.CriadoEm = entity.CriadoEm;
                fornecedor.CNPJ = entity.CNPJ;
                fornecedor.Email = entity.Email;
                fornecedor.Nome = entity.Nome;
                fornecedor.Telefone = entity.Telefone;
                fornecedor.Endereco = entity.Endereco;

                _context.Fornecedor.Update(fornecedor);
                _context.SaveChanges();
            }

            return fornecedor;
        }
    }
}
