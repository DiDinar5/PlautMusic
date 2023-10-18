using ProvidingMusic.BusinessLogic.Services.Intefaces;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.BusinessLogic.Services
{
    public class GroupMemberService : GenericService<GroupMember>,IGroupMemberService
    {
        private readonly IGenericRandomService<GroupMember> _genericRandomBLL;
        private readonly IGroupMemberRepository _groupMemberRepository;
        public GroupMemberService(IGenericRepository<GroupMember> genericRepository,
            IGenericRandomService<GroupMember> genericRandomBLL,
            IGroupMemberRepository groupMemberRepository) :base(genericRepository) 
        {
            _genericRandomBLL = genericRandomBLL;
            _groupMemberRepository = groupMemberRepository;
        }
        public async Task<GroupMember> GetRandomAsync()
        {
            return await _genericRandomBLL.GetRandomAsync();
        }
        public async Task<GroupMember> GetGroupMemberByNameAsync(string name)
        {
            return await _groupMemberRepository.GetGroupMemberByNameAsync(name);
        }
    }
}
