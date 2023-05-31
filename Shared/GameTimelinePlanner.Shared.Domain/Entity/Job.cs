using GameTimelinePlanner.Shared.Domain.Entity;
using GameTimelinePlanner.Shared.Domain.Interface;

namespace GameTimelinePlanner.Shared.Domain.Entity;

public class Job : IDisplayable
{
    public Job(string name, Role role, IList<Skill> skills, DisplayDescription displayDescription)
    {
        Name = name;
        Role = role;
        Skills = skills;
        DisplayDescription = displayDescription;
    }

    public string Name { get; set; }
    public Role Role { get; set; }
    public IList<Skill> Skills { get; set; }
    public DisplayDescription DisplayDescription { get; init; }
}