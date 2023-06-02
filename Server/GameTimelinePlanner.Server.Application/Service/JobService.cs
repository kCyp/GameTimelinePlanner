using GameTimelinePlanner.Shared.Domain.Entity;
using GameTimePlanner.Application.Interface;
using Microsoft.Extensions.Logging;

namespace GameTimePlanner.Application.Service;

public class JobService : IJobService
{
    private readonly ILogger<JobService> _logger;
    private readonly IJobRepository _jobRepository;
    private readonly IRepository<Job> _jobRepo;

    public JobService(ILogger<JobService> logger, IJobRepository jobRepository, IRepository<Job> jobRepo)
    {
        _jobRepository = jobRepository;
        _logger = logger;
        _jobRepo = jobRepo;
    }

    public async Task<IList<Job>> Get() {
        return await _jobRepo.Get();
        //return await _jobRepository.Get();
    }
}
