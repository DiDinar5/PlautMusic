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
    public class GroupMemberService : GenericService<GroupMember>,IGroupMemberService
    {
        private readonly IGenericRandomService<GroupMember> _genericRandomBLL;
        public GroupMemberService(IGenericRepository<GroupMember> genericRepository,IGenericRandomService<GroupMember> genericRandomBLL) :base(genericRepository) 
        {
            _genericRandomBLL = genericRandomBLL;
        }
        public async Task<GroupMember> GetRandomEntityConnection()
        {
            return await _genericRandomBLL.GetRandomEntityConnection();
        }
    }
}
