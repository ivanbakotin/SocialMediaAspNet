using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAppBackend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyAppBackend.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DataContext context;
        protected readonly IMapper mapper;

        public Repository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> Get(int ID)
        {
            return await context.Set<T>().FindAsync(ID);
        }

        public async Task<T> Find(Expression<Func<T, bool>> predicate)
        {
            return await context.Set<T>().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> predicate)
        {
            return await context.Set<T>().Where(predicate).ToListAsync();
        }

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }

        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
        }
    }
}
