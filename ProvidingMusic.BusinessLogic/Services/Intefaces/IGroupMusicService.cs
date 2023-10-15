using ProvidingMusic.Database.DTO;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.BusinessLogic.Services.Intefaces
{
    public interface IGroupMusicService: IGenericService<GroupMusic>,
        IGenericRandomService<GroupMusic>,
        IGenericSearchByNameService<GroupMusic>
    {
        Task<GroupMusicDTO?> GetAllInfoGroupMusic(int id);
    }
}