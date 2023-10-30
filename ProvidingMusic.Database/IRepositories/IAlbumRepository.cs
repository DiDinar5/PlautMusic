using ProvidingMusic.DataBase.DTO;
using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.Database.IRepositories
{
    public interface IAlbumRepository : IGenericRepository<Album>, 
        IGenericRandomRepository<Album>,
        IGenericSearchByNameRepository<Album>
    {
        Task<IEnumerable<GetAlbumInfoResponseDTO>> GetAlbum(string bandName);
    }
}
