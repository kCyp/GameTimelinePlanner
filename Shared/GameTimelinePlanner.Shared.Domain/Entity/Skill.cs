using System.Dynamic;
using GameTimelinePlanner.Shared.Domain.Interface;

namespace GameTimelinePlanner.Shared.Domain.Entity;

public class Skill : IDisplayable
{
    public Skill(string name, int requiredLevel, int? levelMax, decimal duration, decimal cooldown, 
                IList<string>? similarSkills, IList<string>? sharedCooldowns, 
                string description, DisplayDescription displayDescription)
    {
        Name = name;
        RequiredLevel = requiredLevel;
        LevelMax = levelMax;
        Duration = duration;
        Cooldown = cooldown;
        SimilarSkills = similarSkills;
        SharedCooldowns = sharedCooldowns;
        Description = description;
        DisplayDescription = displayDescription;
    }

    public string Name { get; private init; }
    public int RequiredLevel { get; private init; }
    public int? LevelMax{ get; private init; }
    public decimal Duration { get; private init; }
    public decimal Cooldown { get; private init; }
    public IList<string>? SimilarSkills { get; private init; }
    public IList<string>? SharedCooldowns { get; private init; }
    public string Description { get; private init; }
    public DisplayDescription DisplayDescription { get; init; }

    public override int GetHashCode()
    {
        return Name.GetHashCode() + RequiredLevel.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Skill skill)
        {
            return false;
        }
        return (Name + RequiredLevel.ToString()).Equals(skill.Name + RequiredLevel.ToString());
    }

    public bool IsUsableAtLevel(int level) 
    {
        return RequiredLevel <= level &&
            LevelMax == null || level < LevelMax;
    }
}