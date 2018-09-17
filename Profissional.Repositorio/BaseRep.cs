using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            //int id = 0;
            //foreach (TEntity item in items)
            //{
            //    db.Entry(item).State = EntityState.Added;
            //    dynamic idT = item;
            //    id = idT.ID;

            //}
            // db.SaveChanges();
            //return  id;

            var item = items.FirstOrDefault();
            db.Entry(item).State = EntityState.Added;
            db.SaveChanges();

            return (item as dynamic).ID;
        }

        public async Task<List<TEntity>> GetAll()
        {
            var list = new Contexto().Set<TEntity>();
            return await list.ToListAsync();
        }

        public void Remove(params TEntity[] items)
        {
            foreach (TEntity item in items)
            {
                db.Entry(item).State = EntityState.Deleted;
            }
            db.SaveChanges();
        }

        public void Update(params TEntity[] items)
        {

            foreach (TEntity item in items)
            {
                db.Entry(item).State = EntityState.Modified;
            }
            db.SaveChanges();
        }

        /// <summary>
        /// Usado para pegar todos utilizando Lambda Expression
        /// </summary>
        /// <param name="where">Sintaxe where para selecionar uma clausula</param>
        /// <param name="navigationProperties">Classe Operante</param>
        /// <returns>Lista filtrada</returns>
        public virtual IList<TEntity> GetList(Func<TEntity, bool> where,
             params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            List<TEntity> list = new List<TEntity>();

            IQueryable<TEntity> dbQuery = db.Set<TEntity>().AsQueryable();

            var query = db.Set<TEntity>().AsQueryable();

            //Apply eager loading

            foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<TEntity, object>(navigationProperty);

            list = dbQuery
                .AsNoTracking()
                .Where(where)
                .ToList<TEntity>();


            return list;
        }
    }
}
