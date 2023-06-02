using GameTimelinePlanner.Shared.Domain.Entity;
using GameTimePlanner.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GameTimelinePlanner.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;
        private readonly IGameService _gameService;
        

        public GameController(ILogger<GameController> logger, IGameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }

        [HttpGet("jobs")]
        public async Task<IList<Job>> GetJobs()
        {
            return await _gameService.GetJobs();
        }
        
        [HttpGet("duties")]
        public async Task<IList<Duty>> GetDuties()
        {
            return await _gameService.GetDuties();
        }
    }
}