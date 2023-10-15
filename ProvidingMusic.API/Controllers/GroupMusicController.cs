using Microsoft.AspNetCore.Mvc;
using ProvidingMusic.BusinessLogic.Services.Intefaces;
using ProvidingMusic.Database.DTO;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;
using System.Globalization;

namespace ProvidingMusic.API.Controllers
{
    [Route("api/musicGroup")]
    [ApiController]
    public class GroupMusicController : Controller
    {
        private readonly IGroupMusicService _musicService;
        public GroupMusicController(IGroupMusicService musicService)
        {
            _musicService = musicService;
        }

        ///<summary>
        ///Посмотреть все музыкальные группы
        ///</summary>
        ///<returns></returns>

        [HttpGet]
        public async Task<IActionResult> GetMusicGroups()
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            
            return Ok(await _musicService.GetAllAsync());
        }
      
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupMusicDTO?>> GetAllInfoGroupMusic(int id)
        {
            return await _musicService.GetAllInfoGroupMusic(id);
        }

        [HttpGet("getGroupMusicByName")]
        public async Task<IActionResult> GetGroupMusicByName(string name)
        {
            return Ok(await _musicService.GetByNameAsync(name));
        }
        [HttpGet("randomGroupMusic")]
        public async Task<IActionResult> GetGroupMusicRandom()
        {
            return Ok(await _musicService.GetRandomAsync());
        }
        [HttpPost("createGroupMusic")]
        public async Task<IActionResult> CreateMusicGroup(GroupMusic groupMusic)
        {
            return Ok(await _musicService.CreateAsync(groupMusic));
        }
        [HttpPatch("updateGroupMusic")]
        public async Task<IActionResult> UpdateGroupMusic(GroupMusic groupMusic)
        {
            return Ok(await _musicService.UpdateAsync(groupMusic));
        }
        [HttpDelete("deleteGroupMusic")]
        public async Task<IActionResult> DeleteGroupMusic(int id)
        {
            return Ok(await _musicService.DeleteAsync(id));
        }
    }
}
