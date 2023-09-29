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
        public async Task<IEnumerable<Song>> GetSongsConnection()
        {
            return await _songRepository.GetSongsFromDbAsync();
        }
        public async Task<Song> GetSongByIdConnection(string name)
        {
            return await _songRepository.GetSongByIdFromDbAsync(name);
        }


    }
}
