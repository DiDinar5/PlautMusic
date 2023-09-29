using Microsoft.AspNetCore.Mvc;
using ProvidingMusic.BusinessLogic.Services.Intefaces;
using System.Globalization;

namespace ProvidingMusic.API.Controllers
{
    [Route("api/groupMember")]
    [ApiController]
    public class GroupMemberController : Controller
    {
        private readonly IGroupMemberBLL _groupMemberBLL;
        public GroupMemberController(IGroupMemberBLL groupMemberBLL)
        {
            _groupMemberBLL = groupMemberBLL;
        }
        [HttpGet]
        public async Task<IActionResult> GetGroupMembers()
        {
            return Ok(await _groupMemberBLL.GetGroupMembersConnection());
        }
        [HttpGet("{nickname}")]
        public async Task<IActionResult> GetGroupMember(string nickname)
        {
            return Ok(await _groupMemberBLL.GetGroupMemberByIdConnection(nickname));
        }
    }
}
