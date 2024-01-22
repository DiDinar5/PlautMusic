using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.Database.IRepositories
{
    public interface IGenericRandomRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity?> GetRandomAsync();
    }
}
