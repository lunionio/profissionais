using Profissional.Dominio.Entidades;
using Profissional.Repositorio;
using Profissional.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Profissional.Servico
{
    public class CategoriaService : IService<Categoria>
    {
        private readonly CategoriaRepository _repository;

        public CategoriaService(CategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Categoria>> GetAllAsync(int idCliente, string token)
        {
            try
            {
                await SeguracaServ.ValidaTokenAsync(token);

                var result = _repository.GetList(c => c.IdCliente.Equals(idCliente));
                return result;
            }
            catch(Exception e)
            {
                throw new Exception("Não foi possível listar as categorias disponíveis.", e);
            }
        }

        public Task<Categoria> GetByIdAsync(int entityId, int idCliente, string token)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Categoria entity, string token)
        {
            throw new NotImplementedException();
        }

        public Task<Categoria> SaveAsync(Categoria entity, string token)
        {
            throw new NotImplementedException();
        }

        public Task<Categoria> UpdateAsync(Categoria entity, string token)
        {
            throw new NotImplementedException();
        }
    }
}
