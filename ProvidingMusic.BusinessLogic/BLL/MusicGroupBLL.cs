using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.BusinessLogic.Services
{
    public class MusicGroupBLL
    {
        private IGroupRepository _musicGroupRepository;
        public async Task<GroupMusic> GetMusicGroups()
        {
            return await _musicGroupRepository.GetGroupsAsync();
        }
    }
}
