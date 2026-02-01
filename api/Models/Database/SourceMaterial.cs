namespace api.Models.Database;

/// <summary>
///     Represents the source (book, AP, etc.) from whence an item comes.
/// </summary>
public class SourceMaterial
{
    public int Id { get; set; }

    public required string Name { get; set; }
}
