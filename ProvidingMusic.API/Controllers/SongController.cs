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
        [HttpGet]
        public async Task<IActionResult> GetSongs()
        {
            return Ok(await _songBLL.GetSongsConnection());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSong(int id)
        {
            return Ok(await _songBLL.GetSongByIdConnection(id));
        }
    }
}
