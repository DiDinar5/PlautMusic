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
    public class GroupMusicBLL : IGroupMusicBLL
    {
        private readonly IGroupMusicRepository _groupMusicRepository;
        public GroupMusicBLL(IGroupMusicRepository groupMusicRepository)
        {
            _groupMusicRepository = groupMusicRepository;
        }
        public async Task<IEnumerable<GroupMusic>> GetGroupsConnection()
        {
            return await _groupMusicRepository.GetGroupsFromDbAsync();
        }
        public async Task<GroupMusic> GetGroupByIdConnection(int id)
        {
            return await _groupMusicRepository.GetGroupByIdFromDbAsync(id);
        }
    }
}
