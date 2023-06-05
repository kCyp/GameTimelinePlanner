using GameTimelinePlanner.Shared.Domain.Entity;

namespace GameTimelinePlanner.Server.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var dd = new DisplayDescription {};
        var skill1 = new Skill("Skill 1", 10, 30, "", dd, 80);
        var skill2 = new Skill("Skill 2", 20, 60, "", dd, 80);
        var skill3 = new Skill("Skill 3", 60, 90, "", dd, 80);

        var DRK = new Job( "DRK", 0, null, new List<Skill> { skill1, skill3 }, dd);
        var WAR = new Job( "WAR", 0, null, new List<Skill> { skill2, skill3 }, dd);

        var player1 = new Player("Player 1", DRK, new Dictionary<Skill, IList<int>>(), dd);
        var player2 = new Player("Player 2", DRK, new Dictionary<Skill, IList<int>>(), dd);
        var player3 = new Player("Player 3", WAR, new Dictionary<Skill, IList<int>>(), dd);

        var roster = new Roster(
            new List<Player> { player1, player2, player3 }
        );

        var duty = new Duty("Omega", "TOP", DutyDifficulty.Ultimate, 90, 635, "6.31", dd);

        var timeline = new Timeline( duty, roster);
        timeline.UseSkill(player1, skill1, 50); //stops at 60
        timeline.UseSkill(player2, skill3, 50); //stops at 70
        timeline.UseSkill(player3, skill3, 20); //stops at 80
        
        Assert.False( player1.HasSkillActive(skill1, 19) );
        Assert.True( player1.HasSkillActive(skill1, 50) );
        Assert.True( player1.HasSkillActive(skill1, 55) );
        Assert.True( player1.HasSkillActive(skill1, 60) );
        Assert.False( player1.HasSkillActive(skill1, 61) );

        Assert.False( player1.HasSkillActive(skill3, 55) );
        Assert.False( player2.HasSkillActive(skill1, 55) );

	}
}
