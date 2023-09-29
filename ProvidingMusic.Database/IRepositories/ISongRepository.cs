using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.Database.IRepositories
{
    public interface ISongRepository
    {
        Task<IEnumerable<Song>> GetSongsFromDbAsync();
        Task<Song> GetSongByIdFromDbAsync(string name);
    }
}
