using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Profissional.Dominio.Interfaces;
using Profissional.Infra;

namespace Profissional.Repositoriox
{
    public class BaseRep<TEntity> : IBase<TEntity> where TEntity : class
    {
        private Contexto db = new Contexto();
        public int Add(params TEntity[] items)
        {
            int id = 0;
            foreach (TEntity item in items)
            {
                db.Entry(item).State = EntityState.Added;
                dynamic idT = item;
                id = idT.ID;

            }
             db.SaveChanges();
            return  id;
        }

        public async Task<List<TEntity>> GetAll()
        {
            var list = new Contexto().Set<TEntity>();
            return await list.ToListAsync();
        }

        public void Remove(params TEntity[] items)
        {
            var context = new Contexto();
            foreach (TEntity item in items)
            {
                context.Entry(item).State = EntityState.Deleted;
            }
            context.SaveChanges();
        }

        public void Update(params TEntity[] items)
        {
            var context = new Contexto();
            foreach (TEntity item in items)
            {
                context.Entry(item).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}
