using System.Collections;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using GameTimelinePlanner.Shared.Domain.Interface;

namespace GameTimelinePlanner.Shared.Domain.Entity;

public class Player : IDisplayable, IIdentifiable<string>
{

    public Player(string name, Job job, PlayerTimeline playerTimeline,
                DisplayDescription displayDescription)
    {
        Name = name;
        Job = job;
        DisplayDescription = displayDescription;
        Timeline = playerTimeline;
    }

    public Player(Job job)
    {
        Job = job;
        Name = string.Empty;
        DisplayDescription = new DisplayDescription();
        Timeline = new PlayerTimeline();
    }

    public Player()
    {
        Name = string.Empty;
        DisplayDescription = new DisplayDescription();
        Timeline = new PlayerTimeline();
    }

    // TODO: need a better unique identifier
    public string Name { get; set; }
    public Job? Job { get; set; }
    public int? Level { get; set; }

    public PlayerTimeline Timeline { get; set; }
    
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
        return Job.SkillsAtLevel(Level);
    }

    public bool HasSkill(Skill skill) 
    {
        return GetSkills().Contains(skill);
    }

}