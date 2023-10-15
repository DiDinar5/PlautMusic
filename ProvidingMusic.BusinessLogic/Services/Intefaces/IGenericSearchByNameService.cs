using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.BusinessLogic.Services.Intefaces
{
    public interface IGenericSearchByNameService<T> where T : NameEntity
    {
        Task<T> GetByNameAsync(string name);
    }
}
