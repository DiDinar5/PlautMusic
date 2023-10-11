using Microsoft.EntityFrameworkCore;
using ProvidingMusic.Database.Context;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.Database.Repositories
{
    public class GroupMusicRepository : GenericRepository<GroupMusic>, IGroupMusicRepository
    {
        private readonly IGenericRandomRepository<GroupMusic> _genericRandomRepository;
        private readonly IGenericSearchByNameRepository<GroupMusic> _genericSearchByNameRepository;
        public GroupMusicRepository(ApplicationDBContext dBContext,
            IGenericRandomRepository<GroupMusic> genericRandomRepository,
            IGenericSearchByNameRepository<GroupMusic> genericSearchByNameRepository) : base(dBContext) 
        {
            _genericRandomRepository = genericRandomRepository;
            _genericSearchByNameRepository = genericSearchByNameRepository;
        }

        public async Task<GroupMusic> GetRandomEntityFromDbAsync()
        {
            return await _genericRandomRepository.GetRandomEntityFromDbAsync();
        }
        public async Task<GroupMusic> SearchByNameAsync(string name)
        {
            return await _genericSearchByNameRepository.SearchByNameAsync(name);
        }
    }
}
