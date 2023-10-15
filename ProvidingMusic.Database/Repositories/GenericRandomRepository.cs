using Microsoft.EntityFrameworkCore;
using ProvidingMusic.Database.Context;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.Database.Repositories
{
    public class GenericRandomRepository<T> : IGenericRandomRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDBContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRandomRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
            _dbSet = _dbContext.Set<T>();
        }
        public async Task<T> GetRandomAsync()
        {
            Random random = new Random();
            var randomIndex = random.Next(0, _dbSet.Count());
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == randomIndex);
        }
    }
}
