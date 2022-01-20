using Application.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories.Base
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly dbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepositoryAsync(dbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveChanges();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await SaveChanges();
            return entity;
        }

        private async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }

    }
}
