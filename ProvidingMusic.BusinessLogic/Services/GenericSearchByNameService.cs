﻿using ProvidingMusic.BusinessLogic.Services.Intefaces;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.BusinessLogic.Services
{
    public class GenericSearchByNameService<T> : IGenericSearchByNameService<T> where T : NameEntity
    {
        protected readonly IGenericSearchByNameRepository<T> _repository;
        public GenericSearchByNameService(IGenericSearchByNameRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task<T> GetEntityByName(string name)
        {
            return await _repository.SearchByNameAsync(name);
        }
    }
}
