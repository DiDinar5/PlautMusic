using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.Database.IRepositories
{
    public interface IGenericSearchByNameRepository<T> where T : NameEntity
    {
        Task<T> GetByNameAsync(string name);
    }
}
