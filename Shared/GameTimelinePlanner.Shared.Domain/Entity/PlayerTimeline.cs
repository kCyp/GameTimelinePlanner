using System.Collections;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using GameTimelinePlanner.Shared.Domain.Interface;

namespace GameTimelinePlanner.Shared.Domain.Entity;

public class PlayerTimeline
{
    public PlayerTimeline()
    {
        SkillsUsage = new Dictionary<Skill, IList<SkillUsage>>();
        EffectsInstances = new Dictionary<SkillEffect, IList<EffectInstance>>();
    }

    public IDictionary<Skill, IList<SkillUsage>> SkillsUsage { get; set; }
    public IDictionary<SkillEffect, IList<EffectInstance>> EffectsInstances { get; set; }
    public bool AddSkill(Skill skill, decimal useTime)
    {
        var success = true;
        if (!SkillsUsage.TryGetValue(skill, out IList<SkillUsage>? usages))
        {
            usages = new List<SkillUsage>();
            SkillsUsage.Add(skill, usages);
        }
        usages.Add(new SkillUsage(skill, useTime));

        foreach ( SkillEffect effect in skill.Effects )
        {
            if (!EffectsInstances.TryGetValue(effect, out IList<EffectInstance>? instances))
            {
                instances = new List<EffectInstance>();
                EffectsInstances.Add(effect, instances);
            }
            instances.Add( new EffectInstance(effect, useTime) );
        }
        return success;
    }

    public void RemoveSkill(Skill skill, decimal time)
    {
        if ( SkillsUsage.TryGetValue(skill, out IList<SkillUsage>? usages) &&
            usages.Any(su => su.StartTime == time) )
        {
            var skillUsageToDelete = usages.First(su => su.StartTime == time);
            usages.Remove(skillUsageToDelete);
        }
        
        foreach ( SkillEffect effect in skill.Effects )
        {
            if ( EffectsInstances.TryGetValue(effect, out IList<EffectInstance>? instances) &&
                instances.Any(instance => instance.StartTime == time) )
            {
                var effectInstanceToDelete = instances.First(effInst => effInst.StartTime == time);
                instances.Remove(effectInstanceToDelete);
            }
        }
    }

    public bool HasSkillAtExactStartTime(Skill skill, decimal time)
    {
        return
            SkillsUsage.ContainsKey(skill) &&
            SkillsUsage[skill].Any(usage => usage.StartTime == time);
    }

    public bool IsEffectActive(SkillEffect skillEffect, decimal time)
    {
        return
            EffectsInstances.ContainsKey(skillEffect) &&
            EffectsInstances[skillEffect].Any(effect => effect.IsActiveAt(time));
    }

    public bool IsSkillInCooldown(Skill skill, decimal time)
    {
        return 
            SkillsUsage.ContainsKey(skill) &&
            SkillsUsage[skill].Any(t => t.IsInCooldownAt(time));
    }

    public bool IsSkillReady(Skill skill, decimal time)
    {
        return 
            !SkillsUsage.ContainsKey(skill) ||
            SkillsUsage[skill].All(t => !t.IsInCooldownAt(time));
    }

    public IList<SkillEffect> GetActiveEffects(decimal time)
    {
        return EffectsInstances.Keys
                  .Where(effect => IsEffectActive(effect, time))
                  .ToList();
    }
}