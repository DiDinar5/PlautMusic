using ProvidingMusic.DataBase.DTO;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.Database.IRepositories
{
    public interface IAlbumRepository : IGenericRepository<Album>, 
        IGenericRandomRepository<Album>,
        IGenericSearchByNameRepository<Album>
    {
        Task<IEnumerable<GetAlbumInfoResponseDTO>> GetAlbum(string bandName);
        string GetSongsFromAlbum(int id);
    }
}
