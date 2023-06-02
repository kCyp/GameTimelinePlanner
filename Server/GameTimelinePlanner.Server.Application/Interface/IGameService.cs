using GameTimelinePlanner.Shared.Domain.Entity;

namespace GameTimePlanner.Application.Interface;

public interface IGameService
{
    Task<IList<Job>> GetJobs(); 
    Task<IList<Duty>> GetDuties(); 
}