using GameTimelinePlanner.Shared.Domain.Interface;

namespace GameTimelinePlanner.Shared.Domain.Entity;

public class EffectInstance
{
    public EffectInstance(SkillEffect skillEffect, decimal startTime)
    {
        SkillEffect = skillEffect;
        StartTime = startTime;
    }

    public SkillEffect SkillEffect { get; private init; }
    public decimal StartTime { get; private init; }
    public decimal EndTime => StartTime + SkillEffect.Duration;

    public bool IsActiveAt(decimal time)
    {
        return time > StartTime && 
            time < EndTime;
    }
}