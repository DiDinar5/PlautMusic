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
    public class GroupMemberRepository : GenericRepository<GroupMember>, IGroupMemberRepository
    {
        private readonly IGenericRandomRepository<GroupMember> _genericRandomRepository;
        public GroupMemberRepository(ApplicationDBContext dBContext, IGenericRandomRepository<GroupMember> genericRandomRepository) : base(dBContext)
        {
            _genericRandomRepository = genericRandomRepository;

        }
        public async Task<GroupMember?> GetRandomEntityFromDbAsync()
        {
            return await _genericRandomRepository.GetRandomEntityFromDbAsync();
        }
    }
}
