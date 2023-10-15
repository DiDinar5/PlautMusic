using Microsoft.EntityFrameworkCore;
using ProvidingMusic.Database.Context;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.Database.Repositories
{
    public class GenericSearchByNameRepository<T> : IGenericSearchByNameRepository<T> where T : NameEntity
    {
        protected readonly ApplicationDBContext _dbContext;
        private readonly DbSet<T> _dbSet;   
        public GenericSearchByNameRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
            _dbSet = _dbContext.Set<T>();

        }
        public async Task<T> GetByNameAsync(string name)
        {
            return await _dbSet.FirstAsync(x => EF.Functions.Like(x.Name.ToLower(), $"%{name}%"));
        }
    }
}
