using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using ProvidingMusic.BusinessLogic.Services.Intefaces;
using ProvidingMusic.Domain.Models;
using System.Globalization;

namespace ProvidingMusic.API.Controllers
{
    [Route("api/groupMember")]
    [ApiController]
    public class GroupMemberController : Controller
    {
        private readonly IGroupMemberService _groupMemberBLL;
        public GroupMemberController(IGroupMemberService groupMemberBLL)
        {
            _groupMemberBLL = groupMemberBLL;
        }
        [HttpGet]
        public async Task<IActionResult> GetGroupMembers()
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            return Ok(await _groupMemberBLL.GetAllConnectionAsync());
        }
        [HttpGet("getRandomGroupMember")]
        public async Task<IActionResult> GetGroupMemberRandom()
        {
            return Ok(await _groupMemberBLL.GetRandomEntityConnection());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupMember(int id)
        {
            return Ok(await _groupMemberBLL.GetByIdConnectionAsync(id));
        }
        [HttpPost("createGroupMember")]
        public async Task<IActionResult> CreateGroupMember(GroupMember groupMember)
        {
            return Ok(await _groupMemberBLL.CreateConnectionAsync(groupMember));
        }
        [HttpPatch("updateGroupMember")]
        public async Task<IActionResult> UpdateGroupMember(GroupMember groupMember)
        {
            return Ok(await _groupMemberBLL.UpdateConnectionAsync(groupMember));
        }
        [HttpDelete("deleteGroupMember")]
        public async Task<IActionResult> DeleteGroupMember(int id)
        {
            return Ok(await _groupMemberBLL.DeleteConnectionAsync(id));
        }
    }
}
