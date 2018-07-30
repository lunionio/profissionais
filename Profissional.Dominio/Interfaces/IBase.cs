using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profissional.Dominio.Interfaces
{
    public interface IBase<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        int Add(params TEntity[] items);
        void Update(params TEntity[] items);
        void Remove(params TEntity[] items);

    }
}
