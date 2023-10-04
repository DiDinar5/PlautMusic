using ProvidingMusic.BusinessLogic.Services.Intefaces;
using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.BusinessLogic.Services
{
    public class GenericBLL<TEntity> : IGenericBLL<TEntity> where TEntity : BaseEntity
    {
        public Task<IEnumerable<TEntity>> GetAllConnectionAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdConnectionAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
