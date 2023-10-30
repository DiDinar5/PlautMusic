using AutoMapper;
using ProvidingMusic.Database.DTO;
using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.BusinessLogic.Services.AutoMapper
{
    public class GroupMemberToGroupMemberDTOMapper : Profile
    {
        public GroupMemberToGroupMemberDTOMapper()
        {
            CreateMap<GroupMember, GroupMemberDTO>();
        }
    }
}
