namespace GameTimelinePlanner.Shared.Domain.Entity;

public record ActiveSkill(Skill skill, Player fromPlayer);

public class Timeline
{
    public Roster Roster { get; set; }
    public Duty Duty { get; set; }

    public Timeline(Duty duty, Roster roster)
    {
        Duty = duty;
        Roster = roster;
    }

    public IList<ActiveSkill> GetActiveSkills(int time) 
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

    public void UseSkill(Player player, Skill skill, int time )
    {
        if (!player.HasSkillReady(skill, time)) 
        {
            throw new NotImplementedException();
        }
        player.SkillUsage[skill].Add(time);
    }

}
