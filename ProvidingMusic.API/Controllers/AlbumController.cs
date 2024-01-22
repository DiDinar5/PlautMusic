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
        private readonly IOperationCounterService _operationCounterService;
        public AlbumController(IAlbumService albumService, IOperationCounterService operationCounterService)
        {
            _albumService = albumService;
            _operationCounterService = operationCounterService;

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
        [HttpGet("getAlbumsInfo")]
        public async Task<IActionResult> GetAlbumInfo(string name)
        {
            return Ok(await _albumService.GetAlbumInfo(name));
        }


        [HttpGet("getSongsFromAlbum")]
        public IActionResult GetSongsFromAlbum(int id)
        {
            return Ok(_albumService.GetSongsFromAlbum(id));
        }


        [HttpGet("getAlbumByName")]
        public async Task<IActionResult> GetAlbumByName(string name)
        {
            return Ok(await _albumService.GetByNameAsync(name));
        }

        [HttpGet("getAlbumRandom")]
        public async Task<IActionResult> GetRandomAlbum()
        {
            return Ok(await _albumService.GetRandomAsync());
        }
        [HttpPost("createAlbum")]
        public async Task<IActionResult> CreateAlbum(Album album)
        {
            _operationCounterService.IncreaseAlbumOperationCounter();
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
