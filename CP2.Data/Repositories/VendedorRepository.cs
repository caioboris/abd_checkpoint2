using CP2.Data.AppData;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;

namespace CP2.Data.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly ApplicationContext _context;

        public VendedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public VendedorEntity? DeletarDados(int id)
        {
            var vendedor = _context.Vendedor.Find(id);
            if (vendedor != null)
            {
                _context.Remove(vendedor);
                _context.SaveChanges();
            }
            
            return vendedor;
        }

        public IEnumerable<VendedorEntity> ObterTodos()
        {
            return _context.Vendedor.ToList();
        }

        public VendedorEntity? ObterPorId(int id)
        {
            return _context.Vendedor.FirstOrDefault(x => x.Id == id);
        }

        public VendedorEntity? Inserir(VendedorEntity entity)
        {
            _context.Vendedor.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public VendedorEntity? Atualizar(int id, VendedorEntity entity)
        {
            var vendedor = _context.Vendedor.Find(id);
            
            if(vendedor != null)
            {
                vendedor.ComissaoPercentual = entity.ComissaoPercentual;
                vendedor.MetaMensal = entity.MetaMensal;
                vendedor.DataNascimento = entity.DataNascimento;
                vendedor.CriadoEm = entity.CriadoEm;
                vendedor.DataContratacao = entity.DataContratacao;
                vendedor.Email = entity.Email;
                vendedor.Nome = entity.Nome;
                vendedor.Telefone = entity.Telefone;
                vendedor.Endereco = entity.Endereco;
                
                _context.Vendedor.Update(vendedor);
                _context.SaveChanges();
            }
            
            return vendedor;
        }
    }
}
