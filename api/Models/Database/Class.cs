using System.ComponentModel.DataAnnotations;

namespace api.Models.Database;

/// <summary>
///     Represents a character class
/// </summary>
public class Class
{
    public int Id { get; set; }

    public required string Name { get; set; }

    /// <summary>
    /// First-level key is for the given class level.
    /// Nested dictionary is {spell level: number per day}
    /// </summary>
    /// <example>
    /// To see how many 1st level spells a character of 4th level can cast,
    /// you would do:
    /// <code>SpellsPerDay[4][1]</code>
    /// </example>
    /// <remarks>
    /// This is serialized as JSON to be stored in the database. It shouldn't
    /// be searched over, only grabbed wholesale and returned, so it seemed
    /// like a fair tradeoff for simplicity
    /// </remarks>
    public IDictionary<int, IDictionary<int, int>>? SpellsPerDay { get; set; }

    /// <summary>
    /// Find the highest level spell a class of a given level can cast
    /// </summary>
    /// <param name="characterLevel">The character level</param>
    /// <returns>The highest level, or null if something doesn't exist</returns>
    public int? MaxSpellLevel([Range(1, 20)] int? characterLevel)
    {
        if (characterLevel is null || SpellsPerDay is null)
        {
            return null;
        }

        if (!SpellsPerDay.TryGetValue(characterLevel.Value, out var spellsByLevel))
        {
            return null;
        }

        return spellsByLevel.Keys.Max();
    }
}
