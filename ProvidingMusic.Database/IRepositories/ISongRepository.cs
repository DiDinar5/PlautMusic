using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.Database.IRepositories
{
    public interface ISongRepository: IGenericRepository<Song>,IGenericRandomRepository<Song>,IGenericSearchByNameRepository<Song>
    {
        Task<IEnumerable<Song>>? GetBestSongsFromAlbums(string bandName);
        Song MapSong(int id);

        string GetString(int id);
    }
}

