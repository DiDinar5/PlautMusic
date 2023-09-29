using ProvidingMusic.Domain.Models;
using System.Text.RegularExpressions;

namespace ProvidingMusic.Database.IRepositories
{
    public interface IGroupMusicRepository
    {
        Task<IEnumerable<GroupMusic>> GetGroupsFromDbAsync();
        Task<GroupMusic> GetGroupByIdFromDbAsync(int? musicGroupId);
    }
}
