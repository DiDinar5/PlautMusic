using ProvidingMusic.Database.DTO;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.Database.IRepositories
{
    public interface ISongRepository: IGenericRepository<Song>,IGenericRandomRepository<Song>,IGenericSearchByNameRepository<Song>
    {
        Task<IEnumerable<SongDTO>>? GetLongSongs(string nameAlbum);
        Task<IEnumerable<SongDTO>>? GetBestSongsFromAlbums(string bandName);
    }
}

