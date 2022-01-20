namespace api.Models;

/// <summary>
/// Simple "join" class to help map spells and casters
/// </summary>
public class ClassLevel
{
    public int   Id    { get; set; }
    public Class Class { get; set; }
    public int   Level { get; set; }
}
