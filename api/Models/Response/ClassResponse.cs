namespace api.Models.Response;

/// <summary>
///     Represents a character class
/// </summary>
public class ClassResponse : ISeedable
{
    public string Name { get; set; }

    public IDictionary<int, IDictionary<int, int>>? SpellsPerDay { get; set; }

    public int? MaxSpellLevel(int? characterLevel)
    {
        if (characterLevel is not null && SpellsPerDay is not null)
        {
            return SpellsPerDay[characterLevel.Value].Max().Key;
        }
        return null;
    }
}
