using ProvidingMusic.Database.Data.Migrations;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.BusinessLogic.Services.Intefaces
{
    public interface IGroupMusicService: IGenericService<GroupMusic>,IGenericRandomService<GroupMusic>
    {}
}