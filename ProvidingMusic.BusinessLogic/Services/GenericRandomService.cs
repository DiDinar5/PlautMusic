using ProvidingMusic.BusinessLogic.Services.Intefaces;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.BusinessLogic.Services
{
    public class GenericRandomService<T> : IGenericRandomService<T> where T : BaseEntity
    {
        protected readonly IGenericRandomRepository<T> _repository;
        public GenericRandomService(IGenericRandomRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task<T> GetRandomAsync()
        {
            return await _repository.GetRandomAsync();
        }
    }
}
