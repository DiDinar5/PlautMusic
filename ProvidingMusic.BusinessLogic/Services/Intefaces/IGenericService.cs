using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.BusinessLogic.Services.Intefaces
{
    public interface IGenericService<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllConnectionAsync();
        Task<TEntity> GetByIdConnectionAsync(int id);
        Task<TEntity> CreateConnectionAsync(TEntity entity);
        Task<TEntity> UpdateConnectionAsync(TEntity entity);
        Task<bool> DeleteConnectionAsync(int id);
    }
}
