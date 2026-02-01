namespace api.Models.Response;

public class SpellResponse
{
    public required string Name { get; set; }

    public required string Description { get; set; }
    public required string Summary     { get; set; }

    public List<string>?                    Descriptors     { get; set; }
    public required Dictionary<string, int> ClassLevels     { get; set; }
    public string?                          SpellResistance { get; set; }
    public string?                          SavingThrow     { get; set; }

    public bool HasDivineFocusComponent { get; set; }
    public bool HasFocusComponent       { get; set; }
    public bool HasMaterialComponent    { get; set; }
    public bool HasSomaticComponent     { get; set; }
    public bool HasVerbalComponent      { get; set; }

    public bool    HasCostlyComponents { get; set; }
    public int?    MaterialCosts       { get; set; }
    public string? ComponentDetails    { get; set; }

    public bool IsDismissable { get; set; }
    public bool IsShapeable   { get; set; }

    public bool    IsMythic        { get; set; }
    public string? MythicText      { get; set; }
    public string? MythicAugmented { get; set; }

    public required string CastingTime { get; set; }
    public required string Duration    { get; set; }

    public string? Area    { get; set; }
    public string? Effect  { get; set; }
    public string? Range   { get; set; }
    public string? Targets { get; set; }

    public string? Bloodline       { get; set; }
    public string? Deity           { get; set; }
    public string? Domain          { get; set; }
    public string? HauntStatistics { get; set; }
    public string? Patron          { get; set; }

    public required string School    { get; set; }
    public string?         Subschool { get; set; }

    public required SourceMaterialResponse Source { get; set; }
}
