using Microsoft.AspNetCore.Mvc;
using ProvidingMusic.BusinessLogic.Services.Intefaces;

namespace ProvidingMusic.API.Controllers
{
    [Route("api/operation")]
    [ApiController]
    public class OperationController: Controller
    {
        private readonly IOperationCounterService _operationCounterService;
        public OperationController(IOperationCounterService operationCounterService)
        {
            _operationCounterService = operationCounterService;
        }
        [HttpGet]
        public async Task<List<int>> ShowAllCounters()
        {
            return await _operationCounterService.ShowAllCounters();
        }
    }
}
