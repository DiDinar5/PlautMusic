using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.BusinessLogic.Services.Intefaces
{
    public interface IGenericBLL<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllConnectionAsync();
        Task<TEntity> GetByIdConnectionAsync(int id);
        Task InsertConnectionAsync(TEntity entity);
        Task UpdateConnectionAsync(TEntity entity);
        Task DeleteConnectionAsync(TEntity entity);


    }
}
