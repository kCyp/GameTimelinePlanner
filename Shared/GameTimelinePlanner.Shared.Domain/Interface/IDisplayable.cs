using GameTimelinePlanner.Shared.Domain.Entity;

namespace GameTimelinePlanner.Shared.Domain.Interface;

public interface IDisplayable
{
    DisplayDescription DisplayDescription { get; init; }
}
