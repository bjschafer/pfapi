namespace api.Models.Database;

/// <summary>
///     Represents a character class
/// </summary>
public class Class : ISeedable
{
    public int    Id   { get; set; }
    public string Name { get; set; }
}
