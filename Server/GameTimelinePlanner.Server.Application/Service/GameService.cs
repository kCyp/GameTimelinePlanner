using GameTimelinePlanner.Shared.Domain.Entity;
using GameTimePlanner.Application.Interface;
using Microsoft.Extensions.Logging;

namespace GameTimePlanner.Application.Service;

public class GameService : IGameService
{
    private readonly ILogger<GameService> _logger;
    //private readonly IJobRepository _jobRepository;
    private readonly IRepository<Job> _jobRepo;

    private readonly IRepository<Duty> _dutyRepo;

    public GameService(ILogger<GameService> logger, IRepository<Duty> dutyRepo, IRepository<Job> jobRepo)
    {
        //_jobRepository = jobRepository;
        _logger = logger;
        _jobRepo = jobRepo;
        _dutyRepo = dutyRepo;
        _logger.LogInformation("GameService created");
    }

    public async Task<IList<Job>> GetJobs() {
        return await _jobRepo.Get();
        //return await _jobRepository.Get();
    }
    public async Task<IList<Duty>> GetDuties() {
        return await _dutyRepo.Get();
        //return await _jobRepository.Get();
    }
}
