using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.Database.IRepositories
{
    public interface IGenericSearchByNameRepository<T> where T : NameEntity
    {
        Task<T> GetByNameAsync(string name);
    }
}
