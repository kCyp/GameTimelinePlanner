using System.Collections;
using System.Diagnostics.Tracing;
using GameTimelinePlanner.Shared.Domain.Interface;

namespace GameTimelinePlanner.Shared.Domain.Entity;

public class Player : IDisplayable, IIdentifiable<string>
{

    public Player(string name, Job job, IDictionary<Skill, IList<SkillUsage>> skillUsage,
                DisplayDescription displayDescription)
    {
        Name = name;
        Job = job;
        DisplayDescription = displayDescription;
        SkillsUsage = skillUsage;
    }

    public Player(Job job)
    {
        Job = job;
        Name = string.Empty;
        DisplayDescription = new DisplayDescription();
    }

    public Player()
    {
        Name = string.Empty;
    }

    // TODO: need a better unique identifier
    public string Name { get; set; }
    public Job? Job { get; set; }
    public int? Level { get; set; }

    public IDictionary<Skill, IList<SkillUsage>> SkillsUsage { get; set; } = new Dictionary<Skill, IList<SkillUsage>>();
    public DisplayDescription? DisplayDescription { get; init; }
    public string Id => Name;

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        Player? player = obj as Player;
        if (player == null)
        {
            return false;
        }
        return Name.Equals(player.Name);
    }

    public IList<Skill> GetSkills()
    {
        if (Job == null) 
        {
            return new List<Skill>();
        }
        return Job.Skills.Where(skill => skill.IsUsableAtLevel(Level ?? 999))
            .ToList();
    }

    public bool HasSkill(Skill skill) 
    {
        return GetSkills().Contains(skill);
    }

    public bool AddSkillUsage(Skill skill, decimal useTime)
    {
        var success = true;

        if (!SkillsUsage.TryGetValue(skill, out IList<SkillUsage>? usages))
        {
            usages = new List<SkillUsage>();
            SkillsUsage.Add(skill, usages);
        }

        usages.Add(new SkillUsage(skill, useTime));

        return success;
    }

    public void RemoveSkillUsage(Skill skill, decimal time)
    {
        if (SkillsUsage.ContainsKey(skill)
            && SkillsUsage[skill].Any(su => su.StartTime == time))
        {
            var skillUsageToDelete = SkillsUsage[skill].First(su => su.StartTime == time);
            SkillsUsage[skill].Remove(skillUsageToDelete);
        }
    }

    public bool HasSkillAtExactStartTime(Skill skill, decimal time)
    {
        return
            SkillsUsage.ContainsKey(skill) &&
            SkillsUsage[skill].Any(usage => usage.StartTime == time);
    }

    public bool HasSkillActive(Skill skill, decimal time)
    {
        return
            SkillsUsage.ContainsKey(skill) &&
            SkillsUsage[skill].Any(usage => usage.IsActiveAt(time));
    }

    public bool HasSkillReady(Skill skill, decimal time)
    {
        if (!HasSkill(skill)) 
        { 
            return false; 
        }
        // no key = not used yet
        return !SkillsUsage.ContainsKey(skill) || SkillsUsage[skill].All(t => !t.IsInCooldownAt(time));
    }

    public bool HasSkillInCooldown(Skill skill, decimal time)
    {
        if (!HasSkill(skill))
        {
            return false;
        }

        return SkillsUsage.ContainsKey(skill) && SkillsUsage[skill].Any(t => t.IsInCooldownAt(time));

    }

    public IList<Skill> GetActiveSkills(decimal time)
    {
        return SkillsUsage.Keys
                  .Where(skill => this.HasSkillActive(skill, time))
                  .ToList();
    }
}