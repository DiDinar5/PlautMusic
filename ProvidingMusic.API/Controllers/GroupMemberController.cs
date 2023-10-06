using Microsoft.AspNetCore.Mvc;
using ProvidingMusic.BusinessLogic.Services.Intefaces;
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
    }
}
