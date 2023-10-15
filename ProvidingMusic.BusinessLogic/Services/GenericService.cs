using ProvidingMusic.BusinessLogic.Services.Intefaces;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.BusinessLogic.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : BaseEntity
    {
        protected readonly IGenericRepository<TEntity> _repository;
        public GenericService(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        //public async Task<TEntity> GetByIdConnectionAsync(int id)
        //{
        //    return await _repository.GetByIdAsync(id);
        //}

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var ent  = await _repository.CreateAsync(entity);
            return ent;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            await _repository.UpdateAsync(entity);
            return entity;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
