using GameTimelinePlanner.Shared.Domain.Interface;

namespace GameTimelinePlanner.Shared.Domain.Entity;

public class Skill : IDisplayable
{
    public Skill(string name, int duration, int cooldown, string description, DisplayDescription displayDescription, int requiredLevel)
    {
        Name = name;
        RequiredLevel = requiredLevel;
        Duration = duration;
        Cooldown = cooldown;
        Description = description;
        DisplayDescription = displayDescription;
    }

    public string Name { get; private init; }
    public int RequiredLevel { get; private init; }
    public int Duration { get; private init; }
    public int Cooldown { get; private init; }
    public string Description { get; private init; }
    public DisplayDescription DisplayDescription { get; init; }
}