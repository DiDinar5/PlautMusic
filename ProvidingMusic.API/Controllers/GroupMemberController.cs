using Microsoft.AspNetCore.Mvc;
using ProvidingMusic.BusinessLogic.Services.Intefaces;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.API.Controllers
{
    [Route("api/groupMember")]
    [ApiController]
    public class GroupMemberController : Controller
    {
        private readonly IGroupMemberService _IgroupMemberService;
        private readonly IOperationCounterService _operationCounterService;

        public GroupMemberController(IGroupMemberService IgroupMemberService, IOperationCounterService operationCounterService)
        {
            _IgroupMemberService = IgroupMemberService;
            _operationCounterService = operationCounterService;

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
      
        [HttpPost("createGroupMember")]
        public async Task<IActionResult> CreateGroupMember(GroupMember groupMember)
        {
            _operationCounterService.IncreaseGroupMemberOperationCounter();
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
