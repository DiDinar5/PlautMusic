using ProvidingMusic.BusinessLogic.Services.Intefaces;
using ProvidingMusic.Database.DTO;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.BusinessLogic.Services
{
    public class GroupMusicService : GenericService<GroupMusic>,IGroupMusicService
    {
        private readonly IGenericRandomService<GroupMusic> _genericRandomBLL;
        private readonly IGenericSearchByNameService<GroupMusic> _genericSearchByNameService;
        private readonly IGroupMusicRepository _groupMusicRepository;
        public GroupMusicService(IGenericRepository<GroupMusic> genericRandomRepository,
            IGenericRandomService<GroupMusic> genericRandomBLL,
            IGenericSearchByNameService<GroupMusic> genericSearchByNameService,
            IGroupMusicRepository groupMusicRepository): base(genericRandomRepository) 
        {
            _genericRandomBLL = genericRandomBLL;
            _genericSearchByNameService = genericSearchByNameService;
            _groupMusicRepository = groupMusicRepository;
        }
        public async Task<GroupMusic> GetRandomAsync()
        {
            return await _genericRandomBLL.GetRandomAsync();
        }
        public async Task<GroupMusic> GetByNameAsync(string name)
        {
            return await _genericSearchByNameService.GetByNameAsync(name);
        }

        public async Task<GroupMusicDTO?> GetAllInfoGroupMusic(int id)
        {
            return await _groupMusicRepository.GetAllInfoGroupMusic(id);
        }
    }
}
