    using Microsoft.AspNetCore.Mvc;
using ProvidingMusic.BusinessLogic.Services.Intefaces;
using ProvidingMusic.Database.DTO;
using ProvidingMusic.Domain.Models;

namespace ProvidingMusic.API.Controllers
{
    [Route("api/band")]
    [ApiController]
    public class BandController : Controller
    {
        private readonly IBandService _bandService;
        public BandController(IBandService bandService)
        {
            _bandService = bandService;
        }

        ///<summary>
        ///Посмотреть все музыкальные группы
        ///</summary>
        ///<returns></returns>

        [HttpGet]
        public async Task<IActionResult> GetBands()
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            
            return Ok(await _bandService.GetAllAsync());
        }
      
        [HttpGet("{id}")]
        public async Task<ActionResult<BandDTO?>> GetAllInfo(int id)
        {
            return await _bandService.GetAllInfo(id);
        }

        [HttpGet("getBandByName")]
        public async Task<IActionResult> GetBandByName(string name)
        {
            return Ok(await _bandService.GetByNameAsync(name));
        }
        [HttpGet("randomBand")]
        public async Task<IActionResult> GetBandRandom()
        {
            return Ok(await _bandService.GetRandomAsync());
        }
        [HttpPost("createBand")]
        public async Task<IActionResult> CreateBand(Band groupMusic)
        {
            return Ok(await _bandService.CreateAsync(groupMusic));
        }
        [HttpPatch("updateBand")]
        public async Task<IActionResult> UpdateBand(Band groupMusic)
        {
            return Ok(await _bandService.UpdateAsync(groupMusic));
        }
        [HttpDelete("deleteBand")]
        public async Task<IActionResult> DeleteBand(int id)
        {
            return Ok(await _bandService.DeleteAsync(id));
        }
        //[HttpDelete("deleteAllInfo")]
        //public async Task<IActionResult> DeleteAllInfo(int id)
        //{
        //    return Ok(await _bandService.DeleteAllInfo(id));
        //}

        [HttpPatch("updateAll")]
        public async Task<IActionResult> UpdateAllBands([FromBody]List<BandDTO> bandsDTO)
        {
            return Ok(await _bandService.UpdateAllAsync(bandsDTO));
        }
        [HttpPatch("update")]
        public async Task<IActionResult> UpdateBand([FromBody] BandDTO bandsDTO)
        {
            return Ok(await _bandService.TestSetValues(bandsDTO));
        }
    }
}
