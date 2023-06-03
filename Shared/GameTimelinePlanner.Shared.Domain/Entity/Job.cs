using GameTimelinePlanner.Shared.Domain.Entity;
using GameTimelinePlanner.Shared.Domain.Interface;
using System.Text.Json.Serialization;

namespace GameTimelinePlanner.Shared.Domain.Entity;

public class Job : IDisplayable, IIdentifiable<string>
{
    public Job(string name, RoleType roleType, Role? role, IList<Skill> jobSkills, DisplayDescription displayDescription)
    {
        Name = name;
        RoleType = roleType;
        Role = role;
        JobSkills = jobSkills;
        DisplayDescription = displayDescription;
    }

    public string Name { get; set; }
    public RoleType RoleType { get; private set; }
    public Role? Role { get; private set; }
    public IList<Skill> JobSkills { get; set; }
    public IList<Skill> Skills =>
        JobSkills.Union(Role?.Skills ?? Enumerable.Empty<Skill>())
        .ToList();
    public DisplayDescription DisplayDescription { get; init; }

    public string Id => Name;

    public void SetRole(Role role)
    {
        Role = role;
        RoleType = Role.Type;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        Job? job = obj as Job;
        if (job == null)
        {
            return false;
        }
        return Name.Equals(job.Name);
    }
}