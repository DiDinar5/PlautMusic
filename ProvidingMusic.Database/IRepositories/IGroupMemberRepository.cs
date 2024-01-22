using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.Database.IRepositories
{
    public interface IGroupMemberRepository: IGenericRepository<GroupMember>,
        IGenericRandomRepository<GroupMember>
    {
        Task<GroupMember> GetGroupMemberByNameAsync(string name);
    }
}
