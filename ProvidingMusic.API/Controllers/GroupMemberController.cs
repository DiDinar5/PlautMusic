using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using ProvidingMusic.BusinessLogic.Services;
using ProvidingMusic.BusinessLogic.Services.Intefaces;
using ProvidingMusic.Database.Repositories;
using ProvidingMusic.Domain.Models;
using System.Globalization;

namespace ProvidingMusic.API.Controllers
{
    [Route("api/groupMember")]
    [ApiController]
    public class GroupMemberController : Controller
    {
        private readonly IGroupMemberService _IgroupMemberService;
     //   private readonly GroupMemberService _groupMemberService;

        public GroupMemberController(IGroupMemberService IgroupMemberService)
        {
            _IgroupMemberService = IgroupMemberService;
            //_groupMemberService = groupMemberService;
        }
        [HttpGet]
        public async Task<IActionResult> GetGroupMembers()
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            return Ok(await _IgroupMemberService.GetAllAsync());
        }
        [HttpGet("getGroupMemberByName")]
        public async Task<IActionResult> GetGroupMemberByName(string name)
        {

            return Ok(await _IgroupMemberService.GetGroupMemberByNameAsync(name));
        }
        [HttpGet("getRandomGroupMember")]
        public async Task<IActionResult> GetGroupMemberRandom()
        {
            return Ok(await _IgroupMemberService.GetRandomAsync());
        }
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetGroupMember(int id)
        //{
        //    return Ok(await _IgroupMemberBLL.GetByIdConnectionAsync(id));
        //}
        [HttpPost("createGroupMember")]
        public async Task<IActionResult> CreateGroupMember(GroupMember groupMember)
        {
            return Ok(await _IgroupMemberService.CreateAsync(groupMember));
        }
        [HttpPatch("updateGroupMember")]
        public async Task<IActionResult> UpdateGroupMember(GroupMember groupMember)
        {
            return Ok(await _IgroupMemberService.UpdateAsync(groupMember));
        }
        [HttpDelete("deleteGroupMember")]
        public async Task<IActionResult> DeleteGroupMember(int id)
        {
            return Ok(await _IgroupMemberService.DeleteAsync(id));
        }
    }
}
