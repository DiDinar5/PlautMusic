using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.BusinessLogic.Services.Intefaces
{
    public interface ISongBLL
    {
        Task<IEnumerable<Song>> GetSongsConnection();
        Task<Song> GetSongRandomConnection();
        Task<Song> GetSongByIdConnection(string name);
    }
}
