using ProvidingMusic.BusinessLogic.Services.Intefaces;
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
        public GroupMusicService(IGenericRepository<GroupMusic> genericRandomRepository,
            IGenericRandomService<GroupMusic> genericRandomBLL,
            IGenericSearchByNameService<GroupMusic> genericSearchByNameService): base(genericRandomRepository) 
        {
            _genericRandomBLL = genericRandomBLL;
            _genericSearchByNameService = genericSearchByNameService;
        }
        public async Task<GroupMusic> GetRandomEntityConnection()
        {
            return await _genericRandomBLL.GetRandomEntityConnection();
        }
        public async Task<GroupMusic> GetEntityByName(string name)
        {
            return await _genericSearchByNameService.GetEntityByName(name);
        }

    }
}
