using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.BusinessLogic.Services.Intefaces
{
    public interface IGenericRandomService<T> where T : BaseEntity
    {
        Task<T> GetRandomAsync();
    }
}
