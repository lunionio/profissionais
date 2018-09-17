using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Profissional.Servico.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<T> SaveAsync(T entity, string token);
        Task<IEnumerable<T>> GetAllAsync(int idCliente, string token);
        Task<T> GetByIdAsync(int entityId, int idCliente, string token);
        Task<T> UpdateAsync(T entity, string token);
        Task RemoveAsync(T entity, string token);
    }
}
