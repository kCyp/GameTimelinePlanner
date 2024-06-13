namespace GameTimelinePlanner.Shared.Domain.Entity;

public record ActiveEffect(SkillEffect skillEffect, Player fromPlayer);

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

    public IList<ActiveEffect> GetActiveEffects(decimal time) 
    {
        var _activeEffects = new List<ActiveEffect>();
        foreach( Player player in Roster.Players )
        {
            foreach( SkillEffect effect in player.Timeline.GetActiveEffects(time) )
            {
                _activeEffects.Add( new ActiveEffect(effect, player) );
            }
        }
        return _activeEffects;
    }

    public static void UseSkill(Player player, Skill skill, decimal time )
    {
        player.Timeline.AddSkill(skill, time);
    }

}
