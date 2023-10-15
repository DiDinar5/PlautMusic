using ProvidingMusic.BusinessLogic.Services.Intefaces;
using ProvidingMusic.Database.DataAccess;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Database.Repositories;
using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.BusinessLogic.Services
{
    public class SongService : GenericService<Song>, ISongService
    {
        private readonly IGenericRandomService<Song>   _genericRandomBLL;
        private readonly IGenericSearchByNameService<Song> _searchByName;
        public SongService(IGenericRepository<Song> genericRepository, 
            IGenericRandomService<Song> genericRandomBLL,
            IGenericSearchByNameService<Song> searchByName) : base(genericRepository)
        {
            _genericRandomBLL = genericRandomBLL;
            _searchByName = searchByName;
        }

        public async Task<Song> GetByNameAsync(string name)
        {
            return await _searchByName.GetByNameAsync(name);
        }

        public async Task<Song> GetRandomAsync()
        {
            return await _genericRandomBLL.GetRandomAsync();
        }
    }
}
