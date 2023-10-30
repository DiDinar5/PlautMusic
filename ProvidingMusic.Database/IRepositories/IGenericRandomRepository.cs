using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.Database.IRepositories
{
    public interface IGenericRandomRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity?> GetRandomAsync();
    }
}
