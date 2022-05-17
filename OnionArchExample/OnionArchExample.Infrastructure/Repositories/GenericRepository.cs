using Microsoft.EntityFrameworkCore;
using OnionArchExample.Application.Interfaces.Repository;
using OnionArchExample.Domain.Common;
using OnionArchExample.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchExample.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
           return entity;
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
           
        }

        public async Task<T> GetById(Guid Id)
        {
            return await _dbContext.Set<T>().FindAsync(Id);
        }
    }
}
