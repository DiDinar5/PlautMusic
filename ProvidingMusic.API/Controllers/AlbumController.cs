using Microsoft.AspNetCore.Mvc;
using ProvidingMusic.BusinessLogic.Services.Intefaces;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.API.Controllers
{
    [Route("api/album")]
    [ApiController]
    public class AlbumController : Controller
    {
        private readonly IAlbumService _albumService;
        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAlbums()
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            return Ok(await _albumService.GetAllAsync());
        }
        [HttpGet("getAlbumByName")]
        public async Task<IActionResult> GetAlbumByName(string name)
        {
            return Ok(await _albumService.GetByNameAsync(name));
        }
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetAlbum(int id)
        //{
        //    return Ok(await _albumBLL.GetByIdConnectionAsync(id));
        //}
        [HttpGet("getAlbumRandom")]
        public async Task<IActionResult> GetRandomAlbum()
        {
            return Ok(await _albumService.GetRandomAsync());
        }
        [HttpPost("createAlbum")]
        public async Task<IActionResult> CreateAlbum(Album album)
        {
            return Ok(await _albumService.CreateAsync(album));
        }
        [HttpPatch("updateAlbum")]
        public async Task<IActionResult> UpdateAlbum(Album album)
        {
            return Ok(await _albumService.UpdateAsync(album));
        }
        [HttpDelete("deleteAlbum")]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            return Ok(await _albumService.DeleteAsync(id));
        }
    }
}
