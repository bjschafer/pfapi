namespace api.Models;

/// <summary>
/// A spell has zero or more descriptors that may lead to special effects.
/// </summary>
public class Descriptor : ISeedable
{
    public int    Id   { get; set; }
    public string Name { get; set; }
}
