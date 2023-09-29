using Microsoft.EntityFrameworkCore;
using ProvidingMusic.Database.Context;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.Database.Repositories
{
    public class GroupMemberRepository : IGroupMemberRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public GroupMemberRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<IEnumerable<GroupMember>> GetGropMembersFromDbAsync()=>
            await _dbContext.GroupMembers.OrderBy(x=>x.FirstName).ToListAsync();

        public async Task<GroupMember> GetGroupMemberByIdFromDbAsync(string nickname) =>
            await _dbContext.GroupMembers.Where(x=>x.Nickname==nickname).FirstAsync();
    }
}
