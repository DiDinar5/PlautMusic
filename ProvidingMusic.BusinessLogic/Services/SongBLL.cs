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
    public class SongBLL : ISongBLL
    {
        private readonly ISongRepository _songRepository;
        public SongBLL(ISongRepository songRepository)
        {
            _songRepository = songRepository;
        }

        public Task<IEnumerable<Album>> GetAllConnection()
        {
            return _songRepository.GetAllAsync();
        }

        public Task<Album> GetByIdConnection(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Song> GetSongRandomConnection()
        {
            //try catch
            return await _songRepository.GetSongRandomFromDbAsync();
        }
    }
}
