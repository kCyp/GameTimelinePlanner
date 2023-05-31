using GameTimelinePlanner.Shared.Domain.Entity;

namespace GameTimePlanner.Application.Interface;

public interface IJobService
{
    Task<IList<Job>> Get(); 
}