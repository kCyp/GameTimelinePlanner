using GameTimelinePlanner.Shared.Domain.Entity;
using GameTimePlanner.Application.Interface;
using Microsoft.Extensions.Logging;

namespace GameTimePlanner.Application.Service;

public class GameService : IGameService
{
    private readonly ILogger<GameService> _logger;
    private readonly IRepository<Job, string> _jobRepository;
    private readonly IRepository<Role, RoleType> _roleRepository;
    private readonly IRepository<Duty, string> _dutyRepository;

    public GameService(
        ILogger<GameService> logger,
        IRepository<Job, string> jobRepository,
        IRepository<Role, RoleType> roleRepository,
        IRepository<Duty, string> dutyRepository)
    {
        _logger = logger;
        _jobRepository = jobRepository;
        _roleRepository = roleRepository;
        _dutyRepository = dutyRepository;
        _logger.LogInformation("GameService created");
    }

    public async Task<IList<Job>> GetJobs()
    {
        IList<Job> jobs = await _jobRepository.Get();
        foreach (Job job in jobs)
        {
            Role role = await _roleRepository.GetById(job.RoleType);
            job.SetRole(role);
        }
        return jobs;
    }

    public async Task<IList<Duty>> GetDuties()
    {
        return await _dutyRepository.Get();
    }
}
