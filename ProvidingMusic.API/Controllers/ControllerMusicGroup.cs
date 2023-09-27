using Microsoft.AspNetCore.Mvc;
using ProvidingMusic.Database.IRepositories;

namespace ProvidingMusic.API.Controllers
{
    [Route("api/musicGroup")]
    [ApiController]
    public class ControllerMusicGroup : Controller
    {
        private IGroupRepository musicGroupRepository;
        //public ControllerMusicGroup()
        //{
        //    this.musicGroupRepository = new MusicGroupRepository(new ApplicationDBContext());
        //}
        public ControllerMusicGroup(IGroupRepository musicGroupRepository)
        {
            this.musicGroupRepository = musicGroupRepository;
        }

        ///<summary>
        ///Посмотреть все музыкальные группы
        ///</summary>
        ///<returns></returns>
        
        [HttpGet]
        public async Task<IActionResult> GetMusicGroups()
        {
            //контроллер вызывает сервис из бизнес логики
            return Ok(await musicGroupRepository.GetGroupsAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMusicGroup(int id)
        {
            return Ok(await musicGroupRepository.GetGroupByIdAsync(id));
        }
    }
}
