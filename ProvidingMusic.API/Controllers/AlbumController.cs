using Microsoft.AspNetCore.Mvc;
using ProvidingMusic.BusinessLogic.Services.Intefaces;
using ProvidingMusic.Domain.Models;

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
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            return Ok(await _albumBLL.GetAllConnectionAsync());
        }
        [HttpGet("getAlbumByName")]
        public async Task<IActionResult> GetAlbumByName(string name)
        {
            return Ok(await _albumBLL.GetEntityByName(name));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbum(int id)
        {
            return Ok(await _albumBLL.GetByIdConnectionAsync(id));
        }
        [HttpGet("getAlbumRandom")]
        public async Task<IActionResult> GetRandomAlbum()
        {
            return Ok(await _albumBLL.GetRandomEntityConnection());
        }
        [HttpPost("createAlbum")]
        public async Task<IActionResult> CreateAlbum(Album album)
        {
            return Ok(await _albumBLL.CreateConnectionAsync(album));
        }
        [HttpPatch("updateAlbum")]
        public async Task<IActionResult> UpdateAlbum(Album album)
        {
            return Ok(await _albumBLL.UpdateConnectionAsync(album));
        }
        [HttpDelete("deleteAlbum")]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            return Ok(await _albumBLL.DeleteConnectionAsync(id));
        }
    }
}
