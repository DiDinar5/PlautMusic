using Microsoft.EntityFrameworkCore;
using ProvidingMusic.Database.Context;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.Database.Repositories
{
    public class GroupMusicRepository : GenericRepository<GroupMusic>, IGroupMusicRepository
    {
        private readonly IGenericRandomRepository<GroupMusic> _genericRandomRepository;
        public GroupMusicRepository(ApplicationDBContext dBContext, IGenericRandomRepository<GroupMusic> genericRandomRepository) : base(dBContext) 
        {
            _genericRandomRepository = genericRandomRepository;
        }

        public async Task<GroupMusic> GetRandomEntityFromDbAsync()
        {
            return await _genericRandomRepository.GetRandomEntityFromDbAsync();
        }
    }
}
