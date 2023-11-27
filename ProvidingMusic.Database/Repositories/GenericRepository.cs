using Microsoft.EntityFrameworkCore;
using ProvidingMusic.Database.Context;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.Database.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationDBContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        public GenericRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.OrderBy(x => x.Id).ToListAsync();   
        }
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            //упадет производительность
            await SaveAsync();
            return entity;
        }
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);//attach добавит в бд сущность, даже если ее нет
            await SaveAsync();        //_dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }
        public virtual async Task<bool> DeleteAsync(int? id)
        {
           var db =  (_dbContext.Bands
                .Include(b => b.GroupMembers)
                .Include(b => b.Albums)
                .ThenInclude(a => a.ListSongs).FirstOrDefault(s=>s.Id==id));
            TEntity entity = _dbSet.Find(db.Id);
            _dbSet.Remove(entity);
            await SaveAsync();
            return true;    

        }
        public virtual async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
