using Microsoft.AspNetCore.Mvc;
using ProvidingMusic.BusinessLogic.Services.Intefaces;
using ProvidingMusic.Database.IRepositories;

namespace ProvidingMusic.API.Controllers
{
    [Route("api/musicGroup")]
    [ApiController]
    public class GroupMusicController : Controller
    {
        private readonly IGroupMusicBLL _musicBLL;
        public GroupMusicController(IGroupMusicBLL musicBLL)
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
            return Ok(await _musicBLL.GetGroupsConnection());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMusicGroup(int id)
        {
            return Ok(await _musicBLL.GetGroupByIdConnection(id));
        }
    }
}
