using Microsoft.EntityFrameworkCore;
using ProvidingMusic.Database.Context;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.Database.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private ApplicationDBContext _dbContext;
        public GroupRepository(ApplicationDBContext _dBContext)
        {
            _dbContext = _dBContext;
        }
        public async Task<IEnumerable<GroupMusic>> GetGroupsAsync() =>
             await _dbContext.MusicGroups.OrderBy(x => x.Name).ToListAsync();

        public async Task<GroupMusic> GetGroupByIdAsync(int musicGroupId) =>
            await _dbContext.MusicGroups.FindAsync(musicGroupId);
    }
}
