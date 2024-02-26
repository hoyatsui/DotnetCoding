using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotnetCoding.Core.Interfaces;
using System.Linq.Expressions;

namespace DotnetCoding.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbContextClass _dbContext;

        protected GenericRepository(DbContextClass context)
        {
            _dbContext = context;
        }

        public async Task<bool> Delete(int id)
        {
            T entity = await GetById(id);
            if(entity == null)
            {
                return false;
            }
            _dbContext.Set<T>().Remove(entity);
            int amount = await _dbContext.SaveChangesAsync();
            return amount > 0;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<bool> Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            int amount = await _dbContext.SaveChangesAsync();
            return amount > 0;
        }
        public async Task<IEnumerable<T>> GetMany(Expression<Func<T, bool>> where)
        {
            return await _dbContext.Set<T>().Where(where).ToListAsync();
        }
    }
}
