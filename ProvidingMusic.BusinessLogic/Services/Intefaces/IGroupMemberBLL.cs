﻿using ProvidingMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidingMusic.BusinessLogic.Services.Intefaces
{
    public interface IGroupMemberBLL
    {
        Task<IEnumerable<GroupMember>> GetGroupMembersConnection();
        Task<GroupMember> GetGroupMemberByIdConnection(string nickname);
    }
}
