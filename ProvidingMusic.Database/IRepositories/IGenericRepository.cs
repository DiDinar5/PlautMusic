using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.Database.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    { 
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(int? id);
        Task SaveAsync();
    }
}