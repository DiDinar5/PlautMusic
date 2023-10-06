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
        public async Task<IEnumerable<TEntity>> GetAllConnectionAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdConnectionAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public void CreateConnectionAsync(TEntity entity)
        {
             _repository.CreateAsync(entity);
        }

        public void UpdateConnectionAsync(TEntity entity)
        {
            _repository.UpdateAsync(entity);
        }
        public void DeleteConnectionAsync(TEntity entity)
        {
            _repository.DeleteAsync(entity);
        }
    }
}
