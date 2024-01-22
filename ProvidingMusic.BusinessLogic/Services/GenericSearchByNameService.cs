using ProvidingMusic.BusinessLogic.Services.Intefaces;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.BusinessLogic.Services
{
    public class GenericSearchByNameService<T> : IGenericSearchByNameService<T> where T : NameEntity
    {
        protected readonly IGenericSearchByNameRepository<T> _repository;
        public GenericSearchByNameService(IGenericSearchByNameRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task<T> GetByNameAsync(string name)
        {
            return await _repository.GetByNameAsync(name);
        }
    }
}
