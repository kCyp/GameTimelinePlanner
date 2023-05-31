namespace GameTimelinePlanner.Shared.Domain.Entity;

public class Skill
{
    public Skill(string name, int duration, string description)
    {
        Name = name;
        Duration = duration;
        Description = description;
    }

    public string Name { get; private init; }
    public int Duration { get; private init; }
    public string Description { get; private init; }

}