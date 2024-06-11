namespace GameTimelinePlanner.Client.Model;

public enum IconSize
{
    Small,
    Medium,
    Large,
    Auto
}

public static class IconSizeHelper
{
    public static string ToCssClass(this IconSize? iconSize)
    {
        return iconSize switch
        {
            IconSize.Small => "small",
            IconSize.Medium => "medium",
            IconSize.Large => "large",
            IconSize.Auto => "auto",
            _ => "",
        };
    }
}