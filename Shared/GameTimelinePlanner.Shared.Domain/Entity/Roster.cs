using System.Drawing;

namespace GameTimelinePlanner.Shared.Domain.Entity;

public class Roster
{
    public Roster(int size)
    {
        Size = size;
        Players = new List<Player>();
        for (int i = 0; i < Size; i++)
        {
            Players.Add( new Player() );
        }
    }

    public void SetPlayersLevel(int lvl)
    {
        foreach (Player player in Players)
        {
            player.Level = lvl;
        }
    }
    
    public int Size { get; init; } = 8;
    public IList<Player> Players { get; set; }
    public RosterType RosterType { get; set; }
}
