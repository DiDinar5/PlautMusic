using ProvidingMusic.Database.DTO;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.Database.IRepositories
{
    public interface ISongRepository: IGenericRepository<Song>,IGenericRandomRepository<Song>,IGenericSearchByNameRepository<Song>
    {
        //Task<IEnumerable<Song>>? GetLongSongs(string nameAlbum);
        Task<IEnumerable<Song>>? GetBestSongsFromAlbums(string bandName);
        Song MapSong(int id);
    }
}

