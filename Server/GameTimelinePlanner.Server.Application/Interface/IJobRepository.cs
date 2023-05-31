using GameTimelinePlanner.Shared.Domain.Entity;

namespace GameTimePlanner.Application.Interface;

public interface IJobRepository
{
    Task<IList<Job>> Get();
}
