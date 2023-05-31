namespace GameTimelinePlanner.Shared.Domain.Entity;

public class Roster
{
    public IList<Job> Players { get; set; }

    public Roster(IList<Job> players)
    {
        Players = players;
    }
}
