using Microsoft.EntityFrameworkCore;

namespace api.Models;

[Flags]
public enum Descriptors
{
    Acid,
    Air,
    Chaotic,
    Cold,
    Curse,
    Darkness,
    Death,
    Disease,
    Draconic,
    Earth,
    Electricity,
    Emotion,
    Evil,
    Fear,
    Fire,
    Force,
    Good,
    LanguageDependent,
    Lawful,
    Light,
    Meditative,
    MindAffecting,
    Pain,
    Poison,
    Ruse,
    Shadow,
    Sonic,
    Water,
}

public enum Classes
{
    Adept,
    Alchemist,
    Antipaladin,
    Bard,
    Bloodrager,
    Cleric,
    Druid,
    Hunter,
    Inquisitor,
    Investigator,
    Magus,
    Medium,
    Mesmerist,
    Occultist,
    Oracle,
    Paladin,
    Psychic,
    Ranger,
    Shaman,
    Scald,
    SpellLikeAbility,
    Sorcerer,
    Spiritualist,
    Summoner,
    SummonerUnchained,
    Witch,
    Wizard,
}

[Flags]
public enum Components
{
    DivineFocus,
    Focus,
    Material,
    Somatic,
    Verbal,
}

public class Spell
{
    public int    Id   { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }
    public string Summary     { get; set; }

    public Descriptors?           Descriptors     { get; set; }
    public List<ClassLevel>       ClassLevels     { get; set; }
    public Components             Components      { get; set; }
    public string?                SpellResistance { get; set; }
    public string?                SavingThrow     { get; set; }

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

    public SourceMaterial Source { get; set; }
}
