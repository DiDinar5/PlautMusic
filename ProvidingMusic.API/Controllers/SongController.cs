using Microsoft.AspNetCore.Mvc;
using ProvidingMusic.BusinessLogic.Services.Intefaces;
using ProvidingMusic.Database.DTO;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.API.Controllers
{
    [Route("api/song")]
    [ApiController]
    public class SongController : Controller
    {
        private readonly ISongService _songService;
        public SongController(ISongService songService)
        {
            _songService = songService;
        }
        
        ///<summary>
        ///Метод, который ничего не принимает и возвращает все песни
        ///</summary>
        [HttpGet("getAll")]
        public async Task<IActionResult> GetSongs()
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            return Ok(await _songService.GetAllAsync());
        }
        [HttpGet("getSongByName")]
        public async Task<IActionResult> GetSongByName(string name)
        {
            return Ok(await _songService.GetByNameAsync(name));
        }
        ///<summary>
        ///Метод, который ничего не принимает и возвращает рандомную песню
        ///</summary>
        [HttpGet("getsongRandom")]
        public async Task<IActionResult> GetSongRandom()
        {
            return Ok(await _songService.GetRandomAsync());
        }
        //[HttpGet("getLongSongs")]
        //public async Task<IActionResult> GetLongSong(string nameAlbum)
        //{
        //    return Ok(await _songService.GetLongSongs(nameAlbum));
        //}
        [HttpGet("getBestSongs")]
        public async Task<IActionResult> GetBestSongs(string bandName)
        {
            return Ok(await _songService.GetBestSongsFromAlbums(bandName));
        }
        [HttpGet("mapTestSong")]
        public IActionResult MapSongContr(int id)
        {
            return Ok(_songService.MapSong(id));
        }

        /// <summary>
        /// Метод принимает на вход наименование песни, и возвращает песню или похожее наименование в случае ошибки ввода
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Возвращает код(200,400,500) и выбранную песню</returns>
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetSong(int id)
        //{
        //    //if(string.IsNullOrEmpty(id))
        //    //    return BadRequest(new {Message = "name of song is null"});
        //    //EFfunctionsLike
        //    return Ok(await _songBLL.GetByIdConnectionAsync(id));
        //}
        [HttpPost("createSong")]
        public async Task<IActionResult> CreateSong(Song song)
        {
            return Ok(await _songService.CreateAsync(song));
        }
        [HttpPatch("updateSong")]
        public async Task<IActionResult> UpdateSong(Song song)
        {
            return Ok(await _songService.UpdateAsync(song));
        }
        [HttpDelete("deleteSong")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            return Ok(await _songService.DeleteAsync(id));
        }
    }
}
