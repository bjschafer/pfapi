using System.ComponentModel.DataAnnotations;

namespace api.Models.Database;

/// <summary>
///     A spell has zero or more descriptors that may lead to special effects.
/// </summary>
public class Descriptor : ISeedable
{
    public int Id { get; set; }
    [Key]
    public string Name { get; set; }

    public ICollection<Spell> Spells { get; set; }
}
