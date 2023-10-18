using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.BusinessLogic.Services.Intefaces
{
    public interface IGroupMemberService:IGenericService<GroupMember>,IGenericRandomService<GroupMember>
    {
        Task<GroupMember> GetGroupMemberByNameAsync(string name);
    }
}
