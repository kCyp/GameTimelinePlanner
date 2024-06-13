using GameTimelinePlanner.Shared.Domain.Interface;

namespace GameTimelinePlanner.Shared.Domain.Entity;

public class SkillUsage
{
    public SkillUsage(Skill skill, decimal useTime)
    {
        Skill = skill;
        StartTime = useTime;
    }

    public Skill Skill { get; private init; }
    public decimal StartTime { get; private init; }
    public decimal ReUpTime => StartTime + Skill.Cooldown;

    public bool HasAnEffectActive(decimal time)
    {
        decimal _longestEffectDuration = 0;
        
        SkillEffect? _LongestEffect = Skill.GetLongestEffect();
        if ( _LongestEffect != null )
        {
            _longestEffectDuration = _LongestEffect.Duration;
        }
        return 
            time >= StartTime && 
            time < StartTime + _longestEffectDuration;
    }

    public bool IsInCooldownAt(decimal time)
    {
        return 
            time > StartTime &&
            !HasAnEffectActive(time) && time < ReUpTime;
    }
}