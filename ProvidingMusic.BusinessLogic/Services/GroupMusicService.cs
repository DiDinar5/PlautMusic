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
        public GroupMusicService(IGenericRepository<GroupMusic> genericRandomRepository,IGenericRandomService<GroupMusic> genericRandomBLL): base(genericRandomRepository) 
        {
            _genericRandomBLL = genericRandomBLL;
        }
        public async Task<GroupMusic> GetRandomEntityConnection()
        {
            return await _genericRandomBLL.GetRandomEntityConnection();
        }
    }
}
