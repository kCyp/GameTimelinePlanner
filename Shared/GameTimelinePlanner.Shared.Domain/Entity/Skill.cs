using System.Dynamic;
using GameTimelinePlanner.Shared.Domain.Interface;

namespace GameTimelinePlanner.Shared.Domain.Entity;

public class Skill : IDisplayable
{
    public Skill(string name, int requiredLevel, int? levelMax, decimal cooldown, 
                IList<string>? sharedCooldowns, string description,
                IList<SkillEffect> effects, DisplayDescription displayDescription)
    {
        Name = name;
        RequiredLevel = requiredLevel;
        LevelMax = levelMax;
        Cooldown = cooldown;
        SharedCooldowns = sharedCooldowns;
        Description = description;
        Effects = effects;
        DisplayDescription = displayDescription;
    }

    public string Name { get; private init; }
    public int RequiredLevel { get; private init; }
    public int? LevelMax{ get; private init; }
    public decimal Cooldown { get; private init; }
    public IList<SkillEffect> Effects { get; private init; }
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

    public SkillEffect? GetLongestEffect() {
        //return LongestNonBarrier when other effects exists
        IEnumerable<SkillEffect>? nonBarrierEffects = Effects
            .Where(eff => eff.EffectType != SkillEffectType.Barrier);

        if (nonBarrierEffects.Count() > 0) 
        {
            return nonBarrierEffects
                .OrderByDescending(eff => eff.Duration)
                .FirstOrDefault();
        }
        else {
            return Effects
                .OrderByDescending(eff => eff.Duration)
                .FirstOrDefault();
        }
    }
}