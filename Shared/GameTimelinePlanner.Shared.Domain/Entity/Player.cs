using GameTimelinePlanner.Shared.Domain.Entity;
using GameTimelinePlanner.Shared.Domain.Interface;
using System.Text.Json.Serialization;

namespace GameTimelinePlanner.Shared.Domain.Entity;

public class Player : IDisplayable, IIdentifiable<string>
{

    public Player(string name, Job job, IDictionary<Skill, IList<int>> skillUsage, 
                DisplayDescription displayDescription)
    {
        Name = name;
        Job = job;
        DisplayDescription = displayDescription;
        SkillUsage = skillUsage;
    }

    // TODO: need a better unique identifier
    public string Name { get; set; }
    public Job Job { get; set; }

    public IDictionary<Skill, IList<int>> SkillUsage { get; set; }
    public DisplayDescription DisplayDescription { get; init; }
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

    public bool HasSkillActive(Skill skill, int time) 
    {
        return SkillUsage[skill].Any(t => t + skill.Duration >= time);
    }
    public bool HasSkillReady(Skill skill, int time) {
        return SkillUsage[skill].All(t => t + skill.Cooldown > time);
    }
    
    public IList<Skill> GetActiveSkills(int time) {
        return Job.Skills
                  .Where(skill => this.HasSkillActive(skill, time) )
                  .ToList();
    }
}