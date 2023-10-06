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
    public class GenericRandomService<T> : IGenericRandomService<T> where T : BaseEntity
    {
        protected readonly IGenericRandomRepository<T> _repository;
        public GenericRandomService(IGenericRandomRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task<T> GetRandomEntityConnection()
        {
            return await _repository.GetRandomEntityFromDbAsync();
        }
    }
}
