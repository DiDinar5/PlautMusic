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
        void CreateConnectionAsync(TEntity entity);
        void UpdateConnectionAsync(TEntity entity);
        void DeleteConnectionAsync(TEntity entity);


    }
}
