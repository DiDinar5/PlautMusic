using ProvidingMusic.BusinessLogic.Services.Intefaces;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Database.Repositories;
using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.BusinessLogic.Services
{
    public class SongService : GenericService<Song>, ISongService
    {
        private readonly IGenericRandomService<Song>   _genericRandomBLL;
        public SongService(IGenericRepository<Song> genericRepository, IGenericRandomService<Song> genericRandomBLL) : base(genericRepository)
        {
            _genericRandomBLL = genericRandomBLL;
        }

        public async Task<Song> GetRandomEntityConnection()
        {
            return await _genericRandomBLL.GetRandomEntityConnection();
        }
    }
}
