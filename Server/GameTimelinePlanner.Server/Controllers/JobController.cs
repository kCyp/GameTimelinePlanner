using GameTimelinePlanner.Shared.Domain.Entity;
using GameTimePlanner.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GameTimelinePlanner.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController : ControllerBase
    {
        private readonly ILogger<JobController> _logger;
        private readonly IJobService _jobService;

        public JobController(ILogger<JobController> logger, IJobService jobService)
        {
            _logger = logger;
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<IList<Job>> Get()
        {
            return await _jobService.Get();
        }
    }
}