using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.BusinessLogic.Services.Intefaces
{
    public interface IGroupMusicBLL
    {
        Task<IEnumerable<GroupMusic>> GetGroupsConnection();

        Task<GroupMusic> GetGroupByIdConnection(int id);   
    }
}