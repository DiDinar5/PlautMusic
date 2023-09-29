using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.Database.IRepositories
{
    public interface IGroupMemberRepository
    {
        Task<IEnumerable<GroupMember>> GetGropMembersFromDbAsync();
        Task<GroupMember> GetGroupMemberByIdFromDbAsync(string nickname);
    }
}
