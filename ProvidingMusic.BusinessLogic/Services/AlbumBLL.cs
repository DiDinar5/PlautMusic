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
    public class AlbumBLL : IAlbumBLL
    {
        private readonly IAlbumRepository _albumRepository;
        public AlbumBLL(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository; 
        }
        public async Task<IEnumerable<Album>> GetAlbumsConnection()
        {
            return await _albumRepository.GetAlbumFromDbAsync();   
        }
        public async Task<Album> GetAlbumByIdConnection(int id)
        {
            return await _albumRepository.GetAlbumByIdFromDbAsync(id);
        }

      
    }
}
