using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.Database.IRepositories
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<Album>> GetAlbumFromDbAsync();
        Task<Album> GetAlbumByIdFromDbAsync(int id);   
    }
}
