namespace GameTimelinePlanner.Shared.Domain.Entity;

public class Roster
{
    public IList<Player> Players { get; set; }

    public Roster(IList<Player> players)
    {
        Players = players;
    }
}
