using AutoMapper;
using ProvidingMusic.Database.DTO;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.BusinessLogic.AutoMapper
{
    public class GroupMemberToGroupMemberDTOMapper : Profile
    {
        public GroupMemberToGroupMemberDTOMapper()
        {
            CreateMap<GroupMember, GroupMemberDTO>();
        }
    }
}
