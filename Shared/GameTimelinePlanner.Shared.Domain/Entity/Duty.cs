using GameTimelinePlanner.Shared.Domain.Entity;
using GameTimelinePlanner.Shared.Domain.Interface;

namespace GameTimelinePlanner.Shared.Domain.Entity;

public class Duty : IDisplayable
{
    public Duty(string name, string abbr, DutyDifficulty difficulty, int level, int itemlevel, 
                string releasePatch, DisplayDescription displayDescription)
    {
        Name = name;
        Abbr = abbr;
        Difficulty = difficulty;
        Level = level;
        ItemLevel = itemlevel;
        ReleasePatch = releasePatch;
        DisplayDescription = displayDescription;
    }

    public string Name { get; set; }
    public string Abbr { get; set; }
    public DutyDifficulty Difficulty { get; set; }
    public int Level { get; set; }
    public int ItemLevel { get; set; }
    public string ReleasePatch { get; set; }
    public DisplayDescription DisplayDescription { get; init; }
}