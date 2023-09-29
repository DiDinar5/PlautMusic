using Microsoft.EntityFrameworkCore;
using ProvidingMusic.Database.Context;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.Database.Repositories
{
    public class GroupMusicRepository : IGroupMusicRepository
    {
        private ApplicationDBContext _dbContext;
        public GroupMusicRepository(ApplicationDBContext _dBContext)
        {
            _dbContext = _dBContext;
        }
        public async Task<IEnumerable<GroupMusic>> GetGroupsFromDbAsync() =>
             await _dbContext.GroupsMusic.OrderBy(x => x.Name).ToListAsync();

        public async Task<GroupMusic> GetGroupByIdFromDbAsync(int? musicGroupId) =>
            await _dbContext.GroupsMusic.FindAsync(musicGroupId);
    }
}
