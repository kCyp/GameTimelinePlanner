using GameTimelinePlanner.Shared.Domain.Entity;

namespace GameTimePlanner.Application.Interface;

public interface IRepository<T>
{
    Task<IList<T>> Get();
}
