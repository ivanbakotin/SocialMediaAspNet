using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyAppBackend.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(int ID);
        Task<IEnumerable<T>> GetAll();
        Task<T> Find(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
