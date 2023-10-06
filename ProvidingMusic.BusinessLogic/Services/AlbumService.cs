using ProvidingMusic.BusinessLogic.Services.Intefaces;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.BusinessLogic.Services
{
    public class AlbumService : GenericService<Album>,IAlbumService
    {
        private readonly IGenericRandomService<Album> _genericRandomBLL;
        public AlbumService(IGenericRepository<Album> genericRepository,IGenericRandomService<Album> genericRandomBLL):base(genericRepository) 
        {
            _genericRandomBLL = genericRandomBLL;
        }

        public async Task<Album> GetRandomEntityConnection()
        {
            return await _genericRandomBLL.GetRandomEntityConnection();
        }
    }
}
