using System.Dynamic;
using GameTimelinePlanner.Shared.Domain.Interface;

namespace GameTimelinePlanner.Shared.Domain.Entity;

public class SkillEffect
{
    public SkillEffect(string name, decimal duration, 
            SkillEffectType effectType, DamageType? dmgAffected, int? effectStr, 
            string description, IList<string>? similarEffects)
    {
        Name = name;
        Duration = duration;
        EffectType = effectType;
        EffectStr = effectStr;
        DmgAffected = dmgAffected ?? DamageType.Both;
        Description = description;
        SimilarEffects = similarEffects;
    }

    public string Name { get; private init; }
    public decimal Duration { get; private init; }
    public SkillEffectType EffectType { get; private init; }
    public DamageType? DmgAffected { get; private init; }
    public int? EffectStr {get; private init; }
    public IList<string>? SimilarEffects { get; private init; }
    public string Description { get; private init; } = "";

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}