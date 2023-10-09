using Microsoft.AspNetCore.Mvc;
using ProvidingMusic.BusinessLogic.Services.Intefaces;
using ProvidingMusic.Database.IRepositories;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.API.Controllers
{
    [Route("api/musicGroup")]
    [ApiController]
    public class GroupMusicController : Controller
    {
        private readonly IGroupMusicService _musicBLL;
        public GroupMusicController(IGroupMusicService musicBLL)
        {
            _musicBLL = musicBLL;
        }
        //interface BLL

        ///<summary>
        ///Посмотреть все музыкальные группы
        ///</summary>
        ///<returns></returns>

        [HttpGet]
        public async Task<IActionResult> GetMusicGroups()
        {
            //валидация

            //EFfunctionsLike
            //контроллер вызывает сервис из бизнес логики
            return Ok(await _musicBLL.GetAllConnectionAsync());
        }
        [HttpGet("randomGroupMusic")]
        public async Task<IActionResult> GetGroupMusicRandom()
        {
            return Ok(await _musicBLL.GetRandomEntityConnection());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMusicGroup(int id)
        {
            return Ok(await _musicBLL.GetByIdConnectionAsync(id));
        }
        [HttpPost("createGroupMusic")]
        public async Task<IActionResult> CreateMusicGroup(GroupMusic groupMusic)
        {
            return Ok(await _musicBLL.CreateConnectionAsync(groupMusic));
        }
        [HttpPatch("updateGroupMusic")]
        public async Task<IActionResult> UpdateGroupMusic(GroupMusic groupMusic)
        {
            return Ok(await _musicBLL.UpdateConnectionAsync(groupMusic));
        }
        [HttpDelete("deleteGroupMusic")]
        public async Task<IActionResult> DeleteGroupMusic(int id)
        {
            return Ok(await _musicBLL.DeleteConnectionAsync(id));
        }
    }
}
