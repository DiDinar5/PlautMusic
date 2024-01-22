using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.BusinessLogic.Services.Intefaces
{
    public interface IGenericService<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
