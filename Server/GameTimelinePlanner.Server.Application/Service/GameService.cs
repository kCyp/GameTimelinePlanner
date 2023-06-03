using GameTimelinePlanner.Shared.Domain.Entity;
using GameTimePlanner.Application.Interface;
using Microsoft.Extensions.Logging;

namespace GameTimePlanner.Application.Service;

public class GameService : IGameService
{
    private readonly ILogger<GameService> _logger;
    private readonly IRepository<Job, string> _jobRepository;
    private readonly IRepository<Duty, string> _dutyRepository;

    public GameService(ILogger<GameService> logger, IRepository<Duty, string> dutyRepo, IRepository<Job, string> jobRepo)
    {
        _logger = logger;
        _jobRepository = jobRepo;
        _dutyRepository = dutyRepo;
        _logger.LogInformation("GameService created");
    }

    public async Task<IList<Job>> GetJobs() {
        return await _jobRepository.Get();
    }
    public async Task<IList<Duty>> GetDuties() {
        return await _dutyRepository.Get();
    }
}
