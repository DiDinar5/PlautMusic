using ProvidingMusic.Domain.Models;
using System.Text.RegularExpressions;

namespace ProvidingMusic.Database.IRepositories
{
    public interface IGroupRepository
    {
        Task<IEnumerable<GroupMusic>> GetGroupsAsync();
        Task<GroupMusic> GetGroupByIdAsync(int musicGroupId);
    }
}
