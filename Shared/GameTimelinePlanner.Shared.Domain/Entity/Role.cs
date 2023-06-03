namespace GameTimelinePlanner.Shared.Domain.Entity;

public enum RoleType
{
    Tank,
    Healer,
    Melee,
    MagicalRange,
    PhysicalRange
}

public class Role
{
    public RoleType Type { get; set; }
    public string Name { get; set; }
    public IList<Skill> Skills { get; set; } = new List<Skill>();

    public Role(RoleType type, string name, IList<Skill> skills)
    {
        Type = type;
        Name = name;
        Skills = skills;
    }

    public override int GetHashCode()
    {
        return Type.GetHashCode();
    }
}