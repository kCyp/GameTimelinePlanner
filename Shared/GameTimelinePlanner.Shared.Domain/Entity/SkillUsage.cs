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

    public decimal EndTime => StartTime + Skill.Duration;
    public decimal ReUpTime => StartTime + Skill.Cooldown;

    public bool IsActiveAt(decimal time)
    {
        return time > StartTime && 
            time < EndTime;
    }

    public bool IsInCooldownAt(decimal time)
    {
        return time >= EndTime &&
            time < ReUpTime;
    }
}