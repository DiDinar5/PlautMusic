using Microsoft.AspNetCore.Mvc;
using ProvidingMusic.BusinessLogic.Services.Intefaces;

namespace ProvidingMusic.API.Controllers
{
    [Route("api/song")]
    [ApiController]
    public class SongController : Controller
    {
        private readonly ISongBLL _songBLL;
        public SongController(ISongBLL songBLL)
        {
            _songBLL = songBLL;
        }

        ///<summary>
        ///Метод, который ничего не принимает и возвращает все песни
        ///</summary>
        [HttpGet("getAll")]
        public async Task<IActionResult> GetSongs()
        {
            return Ok(await _songBLL.GetSongsConnection());
        }

        ///<summary>
        ///Метод, который ничего не принимает и возвращает рандомную песню
        ///</summary>
        [HttpGet("getRandom")]
        public async Task<IActionResult> GetSongRandom()
        {
            return Ok(await _songBLL.GetSongRandomConnection());
        }

        /// <summary>
        /// Метод принимает на вход наименование песни, и возвращает песню или похожее наименование в случае ошибки ввода
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Возвращает код(200,400,500) и выбранную песню</returns>
        [HttpGet("{name}")]
        public async Task<IActionResult> GetSong(string name)
        {
            if(string.IsNullOrEmpty(name))
                return BadRequest(new {Message = "name of song is null"});
            //EFfunctionsLike
            return Ok(await _songBLL.GetSongByIdConnection(name));
        }
    }
}
