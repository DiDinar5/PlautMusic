using ProvidingMusic.Database.DTO;
using ProvidingMusic.Domain.Models;
using System.Text.RegularExpressions;

namespace ProvidingMusic.Database.IRepositories
{
    public interface IGroupMusicRepository : IGenericRepository<GroupMusic>,
        IGenericRandomRepository<GroupMusic>,
        IGenericSearchByNameRepository<GroupMusic>
    {
        Task<GroupMusicDTO?> GetAllInfoGroupMusic(int id);
    }
}
