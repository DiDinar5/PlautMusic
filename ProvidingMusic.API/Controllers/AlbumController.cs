using Microsoft.AspNetCore.Mvc;
using ProvidingMusic.BusinessLogic.Services.Intefaces;
using ProvidingMusic.Database.Data.Migrations;

namespace ProvidingMusic.API.Controllers
{
    [Route("api/album")]
    [ApiController]
    public class AlbumController : Controller
    {
        private readonly IAlbumService _albumBLL;
        public AlbumController(IAlbumService albumBLL)
        {
            _albumBLL = albumBLL;
        }
        [HttpGet]
        public async Task<IActionResult> GetAlbums()
        {
            return Ok(await _albumBLL.GetAllConnectionAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbum(int id)
        {
            return Ok(await _albumBLL.GetByIdConnectionAsync(id));
        }
        [HttpGet("getalbumRandom")]
        public async Task<IActionResult> GetRandomAlbum()
        {
            return Ok(await _albumBLL.GetRandomEntityConnection());
        }
    }
}
