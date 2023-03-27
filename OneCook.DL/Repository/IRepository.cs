using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OneCook.DL.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        IEnumerable<T> GetByFilter(Func<T, bool> predicate);
        void Insert(T entity);
        void Update(T entity);
        void Delete(object id);
        bool Exists(Func<T, bool> predicate);
        IEnumerable<T> GetBySql(String sql);
        T FindOne();
        IEnumerable<T> FindAll(Expression<Func<T, bool>> where = null, params Expression<Func<T, object>>[] include);
    }
}