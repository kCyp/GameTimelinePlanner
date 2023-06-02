using GameTimelinePlanner.Shared.Domain.Interface;

namespace GameTimelinePlanner.Shared.Domain.Entity;

public class Skill : IDisplayable
{
    public Skill(string name, int duration, string description, DisplayDescription displayDescription)
    {
        Name = name;
        Duration = duration;
        Description = description;
        DisplayDescription = displayDescription;
    }

    public string Name { get; private init; }
    public int Duration { get; private init; }
    public string Description { get; private init; }
    public DisplayDescription DisplayDescription { get; init; }
}