namespace GameTimelinePlanner.Shared.Domain.Entity;

public record ActiveSkill(Skill skill, Player fromPlayer);

public class Timeline
{
    public Roster Roster { get; set; }
    public Duty? Duty { get; set; }

    public Timeline(Duty duty, Roster roster)
    {
        Duty = duty;
        Roster = roster;
    }
    
    public Timeline()
    {
        Duty = null;
        Roster = new Roster(8);
    }

    public IList<ActiveSkill> GetActiveSkills(decimal time) 
    {
        var _activeSkills = new List<ActiveSkill>();
        foreach( Player player in Roster.Players )
        {
            foreach( Skill skill in player.GetActiveSkills(time) )
            {
                _activeSkills.Add( new ActiveSkill(skill, player) );
            }
        }
        return _activeSkills;
    }

    public void UseSkill(Player player, Skill skill, decimal time )
    {
        /*if (!player.HasSkillReady(skill, time)) 
        {
            throw new NotImplementedException();
        }*/
        if (!player.SkillsUsage.ContainsKey(skill))
        {
            player.SkillsUsage[skill] = new List<SkillUsage>();
        }
        player.SkillsUsage[skill].Add(new SkillUsage(skill, time));
    }

}
