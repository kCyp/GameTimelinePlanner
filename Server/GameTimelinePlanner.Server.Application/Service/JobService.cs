using GameTimelinePlanner.Shared.Domain.Entity;
using GameTimePlanner.Application.Interface;
using Microsoft.Extensions.Logging;

namespace GameTimePlanner.Application.Service;

public class JobService : IJobService
{
    private readonly ILogger<JobService> _logger;
    private readonly IJobRepository _jobRepository;

    public JobService(ILogger<JobService> logger, IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
        _logger = logger;
    }

    public async Task<IList<Job>> Get() {
        return await _jobRepository.Get();
    }
}
