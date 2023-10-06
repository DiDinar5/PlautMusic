﻿using Microsoft.EntityFrameworkCore;
using ProvidingMusic.Database.Context;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.Database.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDBContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        public GenericRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.OrderBy(x => x.Name).ToListAsync();
        }
        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public virtual void CreateAsync(TEntity entity)
        {
            _dbSet.Add(entity);
        }
        public virtual void UpdateAsync(TEntity entity)
        {
            _dbSet.Attach(entity);//update
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void DeleteAsync(object id)
        {
            TEntity entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }
        public virtual void SaveAsync()
        {
            _dbContext.SaveChanges();
        }
    }
}
