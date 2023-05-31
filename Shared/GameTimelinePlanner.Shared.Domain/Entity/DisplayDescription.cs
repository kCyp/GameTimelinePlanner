using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTimelinePlanner.Shared.Domain.Entity;

public class DisplayDescription
{
    public string? IconSource { get; init; }
    public string ColorHex { get; init; }

    public DisplayDescription(string? iconSource, string colorHexa)
    {
        IconSource = iconSource;
        ColorHex = colorHexa;
    }

    public DisplayDescription()
    {
        IconSource = null;
        ColorHex = "#000000";
    }
}
