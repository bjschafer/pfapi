namespace api.Models.Response;

/// <summary>
///     Represents a character class
/// </summary>
public class ClassResponse
{
    public required string Name { get; set; }

    public IDictionary<int, IDictionary<int, int>>? SpellsPerDay { get; set; }
}
