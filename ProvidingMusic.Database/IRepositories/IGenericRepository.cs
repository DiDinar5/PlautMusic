using ProvidingMusic.Domain.Models;
using System.Linq.Expressions;

namespace ProvidingMusic.Database.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    { 
        IEnumerable<TEntity> GetAllAsync();
        TEntity GetByIdAsync(int id);
        void CreateAsync(TEntity entity);
        void UpdateAsync(TEntity entity);
        void DeleteAsync(object id);
        void SaveAsync();
        //Сделать все ассинхронным

    }
}