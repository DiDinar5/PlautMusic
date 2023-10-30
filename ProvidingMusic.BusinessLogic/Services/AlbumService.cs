using ProvidingMusic.BusinessLogic.Services.Intefaces;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.DataBase.DTO;
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
        private readonly IGenericSearchByNameService<Album> _genericSearchByNameService;
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IGenericRepository<Album> genericRepository,
            IGenericRandomService<Album> genericRandomBLL,
            IGenericSearchByNameService<Album> genericSearchByNameService,
            IAlbumRepository albumRepository):base(genericRepository) 
        {
            _genericRandomBLL = genericRandomBLL;
            _genericSearchByNameService = genericSearchByNameService;   
            _albumRepository = albumRepository;
        }

        public async Task<Album> GetRandomAsync()
        {
            return await _genericRandomBLL.GetRandomAsync();
        }
        public async Task<Album> GetByNameAsync(string name)
        {
            return await _genericSearchByNameService.GetByNameAsync(name);
        }

        public async Task<IEnumerable<GetAlbumInfoResponseDTO>> GetAlbumInfo(string bandName)
        {
            return await _albumRepository.GetAlbum(bandName);
        }
    }
}
