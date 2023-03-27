using Microsoft.EntityFrameworkCore;
using OneCook.DL.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OneCook.DL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly DatabaseContext context;
        private readonly DbSet<T> table;

        public Repository(DatabaseContext context)
        {
            this.context = context;
            this.table = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public IEnumerable<T> GetByFilter(Func<T, bool> predicate)
        {
            return table.Where(predicate);
        }

        public void Insert(T entity)
        {
            table.Add(entity);
        }

        public void Update(T entity)
        {
            table.Attach(entity);
            table.Update(entity).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            table.Remove(GetById(id));
        }

        public bool Exists(Func<T, bool> predicate)
        {
            return table.AsNoTracking().Where(predicate).Any();
        }

        public IEnumerable<T> GetBySql(string sql)
        {
            return table.FromSqlRaw(sql);
        }

        public T FindOne()
        {
            T entity = table.FirstOrDefault();
            return entity;
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> where = null, params Expression<Func<T, object>>[] include)
        {
            return Queries(where, include);
        }

        private IQueryable<T> Queries(Expression<Func<T, bool>> expr = null, params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = expr == null ? context.Set<T>() : context.Set<T>().Where(expr);
            if (include != null)
            {
                foreach (Expression<Func<T, object>> includes in include)
                {
                    query = query.Include(includes);
                }
            }
            return query;
        }

    }
}