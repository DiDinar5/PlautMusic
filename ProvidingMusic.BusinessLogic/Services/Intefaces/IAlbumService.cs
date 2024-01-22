using ProvidingMusic.DataBase.DTO;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.BusinessLogic.Services.Intefaces
{
    public interface IAlbumService:IGenericService<Album>,
        IGenericRandomService<Album>,
        IGenericSearchByNameService<Album>
    {
        Task<IEnumerable<GetAlbumInfoResponseDTO>> GetAlbumInfo(string bandName);

        string GetSongsFromAlbum(int id);


    }
}
