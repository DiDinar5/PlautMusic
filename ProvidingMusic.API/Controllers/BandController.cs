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
        private readonly IOperationCounterService _operationCounterService;
        public BandController(IBandService bandService, IOperationCounterService operationCounterService)
        {
            _bandService = bandService;
            _operationCounterService = operationCounterService;

            //_bandCreated += _operationCounterService.OnBandCreated;//подписка
            
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

        //delegate void BandCreatedHandler();
        //event BandCreatedHandler _bandCreated;
       
        [HttpPost("createBand")]
        public async Task<IActionResult> CreateBand(Band groupMusic)
        {
            // _bandCreated?.Invoke();
            //_operationCounterService.IncreaseBandOperationCounter();

            return Ok(await _bandService.CreateTest(groupMusic));
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

        [HttpPatch("updateAll")]
        public async Task<IActionResult> UpdateAllBands([FromBody]List<BandDTO> bandsDTO)
        {
            return Ok(await _bandService.UpdateAllAsync(bandsDTO));
        }
    }
}
