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
    public class GroupMemberBLL : IGroupMemberBLL
    {
        private readonly IGroupMemberRepository _groupMemberRepository;
        public GroupMemberBLL(IGroupMemberRepository groupMemberRepository)
        {
            _groupMemberRepository = groupMemberRepository;
        }
        public async Task<IEnumerable<GroupMember>> GetGroupMembersConnection()
        {
            return await _groupMemberRepository.GetGropMembersFromDbAsync();
        }
        public async Task<GroupMember> GetGroupMemberByIdConnection(string nickname)
        {
            return await _groupMemberRepository.GetGroupMemberByIdFromDbAsync(nickname);
        }

        
    }
}
