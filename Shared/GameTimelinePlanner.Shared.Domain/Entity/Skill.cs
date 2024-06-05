using GameTimelinePlanner.Shared.Domain.Interface;

namespace GameTimelinePlanner.Shared.Domain.Entity;

public class Skill : IDisplayable
{
    public Skill(string name, decimal duration, decimal cooldown, string description, DisplayDescription displayDescription, int requiredLevel)
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
    public decimal Duration { get; private init; }
    public decimal Cooldown { get; private init; }
    public string Description { get; private init; }
    public DisplayDescription DisplayDescription { get; init; }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Skill skill)
        {
            return false;
        }
        return Name.Equals(skill.Name);
    }
}