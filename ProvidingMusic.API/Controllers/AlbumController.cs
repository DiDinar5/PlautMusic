using Microsoft.AspNetCore.Mvc;
using ProvidingMusic.BusinessLogic.Services.Intefaces;

namespace ProvidingMusic.API.Controllers
{
    [Route("api/album")]
    [ApiController]
    public class AlbumController : Controller
    {
        private readonly IAlbumBLL _albumBLL;
        public AlbumController(IAlbumBLL albumBLL)
        {
            _albumBLL = albumBLL;
        }
        [HttpGet]
        public async Task<IActionResult> GetAlbums()
        {
            return Ok(await _albumBLL.GetAlbumsConnection());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbum(int id)
        {
            return Ok(await _albumBLL.GetAlbumByIdConnection(id));
        }
    }
}
