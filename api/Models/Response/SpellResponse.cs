namespace api.Models.Response;

public class SpellResponse
{
    public string Name { get; set; }

    public string Description { get; set; }
    public string Summary     { get; set; }

    public List<string>? Descriptors { get; set; }
    // public Dictionary<Class, int> ClassLevels     { get; set; }
    public Dictionary<string, int> ClassLevels     { get; set; }
    public string?                 SpellResistance { get; set; }
    public string?                 SavingThrow     { get; set; }

    public bool HasDivineFocusComponent { get; set; }
    public bool HasFocusComponent       { get; set; }
    public bool HasMaterialComponent    { get; set; }
    public bool HasSomaticComponent     { get; set; }
    public bool HasVerbalComponent      { get; set; }

    public bool HasCostlyComponents { get; set; }
    public int? MaterialCosts       { get; set; }

    public bool IsDismissable { get; set; }
    public bool IsShapeable   { get; set; }

    public bool    IsMythic        { get; set; }
    public string? MythicText      { get; set; }
    public string? MythicAugmented { get; set; }

    public string CastingTime { get; set; }
    public string Duration    { get; set; }

    public string? Area    { get; set; }
    public string? Effect  { get; set; }
    public string? Range   { get; set; }
    public string? Targets { get; set; }

    public string? Bloodline       { get; set; }
    public string? Deity           { get; set; }
    public string? Domain          { get; set; }
    public string? HauntStatistics { get; set; }
    public string? Patron          { get; set; }

    public string  School    { get; set; }
    public string? Subschool { get; set; }

    public SourceMaterialResponse Source { get; set; }
}
