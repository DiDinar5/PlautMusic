using ProvidingMusic.Database.DTO;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.BusinessLogic.Services.Intefaces
{
    public interface ISongService : IGenericService<Song>,IGenericRandomService<Song>,IGenericSearchByNameService<Song>
    {
        //Task<IEnumerable<SongDTO>> GetLongSongs(string name);
        Task<IEnumerable<SongDTO?>> GetBestSongsFromAlbums(string? bandName);
        SongDTO MapSong(int id);

        string GetString(int id);
    }
}
