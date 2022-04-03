using System.Globalization;
using System.Text.Json;

using api.Models.Request;

using CsvHelper;
using CsvHelper.Configuration;

namespace Data_Helper;

public static class SpellImporter
{
    private static readonly Dictionary<string, string> ShortLongClassNames = new()
    {
        {
            "Wiz", "Wizard"
        },
        {
            "Sor", "Sorcerer"
        },
    };
    public static string ToApiJsonObject(this CsvSpell csvSpell)
    {
        // let's begin by "cheating": we'll actually make a "real" spell object
        var spell = new SpellRequest
        {
            Name                    = csvSpell.Name,
            Area                    = csvSpell.Area,
            Bloodline               = csvSpell.Bloodline,
            CastingTime             = csvSpell.CastingTime,
            ClassSpells             = ParseClasses(csvSpell),
            SpellResistance         = csvSpell.SpellResistance,
            SavingThrow             = csvSpell.SavingThrow,
            HasDivineFocusComponent = csvSpell.DivineFocus,
            HasFocusComponent       = csvSpell.Focus,
            HasMaterialComponent    = csvSpell.Material,
            HasSomaticComponent     = csvSpell.Somatic,
            HasVerbalComponent      = csvSpell.Verbal,
            HasCostlyComponents     = csvSpell.CostlyComponents,
            MaterialCosts           = csvSpell.MaterialCosts,
            IsDismissable           = csvSpell.Dismissible,
            IsShapeable             = csvSpell.Shapeable,
            IsMythic                = csvSpell.Mythic,
            MythicText              = csvSpell.MythicText,
            MythicAugmented         = csvSpell.Augmented,
            Deity                   = csvSpell.Deity,
            Description             = csvSpell.Description,
            Summary                 = csvSpell.ShortDescription, // ? was this what i meant?
            Descriptors             = ParseDescriptors(csvSpell.Descriptor),
            Domain                  = csvSpell.Domain,
            HauntStatistics         = csvSpell.HauntStatistics,
            Patron                  = csvSpell.Patron,
            School                  = csvSpell.School,
            Subschool               = csvSpell.Subschool,
            Source                  = csvSpell.Source,
            Duration                = csvSpell.Duration,
            Effect                  = csvSpell.Effect,
            Range                   = csvSpell.Range,
            Targets                 = csvSpell.Targets,

        };

        return JsonSerializer.Serialize(spell);
    }
    /// <summary>
    ///     the descriptor field is 0 or more words separated by commas
    /// </summary>
    /// <param name="raw">the raw field from the CSV</param>
    /// <returns>a List of descriptors</returns>
    public static List<string>? ParseDescriptors(string? raw)
    {
        if (raw is null)
        {
            return null;
        }
        List<string> ret = new();
        raw = raw.Replace(" or ", ",");
        foreach (var segment in raw.Split(','))
        {
            var cleanSegment = segment
                              .Replace("; see below", "")
                              .Replace("UM", "")
                              .Replace("see text", "")
                              .Replace(";", "")
                              .Trim();
            if (cleanSegment == "law") cleanSegment   = "lawful";
            if (cleanSegment == "chaos") cleanSegment = "chaotic";
            if (!String.IsNullOrWhiteSpace(cleanSegment))
            {
                ret.Add(cleanSegment);
            }
        }

        if (ret.Count == 0)
        {
            return null;
        }
        return ret;
    }

    public static List<ClassSpellRequest> ParseClasses(CsvSpell raw)
    {
        var classes         = new List<ClassSpellRequest>();
        var csvSpellType    = typeof(CsvSpell);
        var classProperties = csvSpellType.GetProperties().Where(p => p.PropertyType == typeof(int?));

        foreach (var classProperty in classProperties)
        {
            var className = classProperty.Name;
            if (ShortLongClassNames.ContainsKey(className))
            {
                className = ShortLongClassNames[className];
            }
            var level = classProperty.GetValue(raw);
            if (level is not null)
            {
                var spellLevel = Convert.ToInt32(level);

                classes.Add(new ClassSpellRequest
                {
                    ClassName = className,
                    Level     = spellLevel,
                });
            }
        }

        return classes;
    }

    /// <summary>
    ///     Takes a CSV file from the SRD and converts it into representative objects
    /// </summary>
    /// <param name="filepath">Path to a CSV file containing spells</param>
    /// <returns>An eager list of spells.</returns>
    public static async Task<IEnumerable<CsvSpell>> ImportSpellFromCsv(string filepath)
    {
        await ReformatNullInFile(filepath);
        var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
        {
            PrepareHeaderForMatch = args => ReformatHeader(args.Header),

        };
        using var streamReader = File.OpenText(filepath);
        using var csvReader    = new CsvReader(streamReader, csvConfig);

        var spells = csvReader.GetRecords<CsvSpell>()
                              .ToList();

        return spells;
    }

    private static async Task ReformatNullInFile(string filepath)
    {
        var fileText = await File.ReadAllTextAsync(filepath);
        fileText = fileText.Replace("NULL", "");
        await File.WriteAllTextAsync(filepath, fileText);
    }

    private static string ReformatHeader(string input)
    {
        // first we need to transform from CamelCase to snake_case
        // and then tolower
        return string.Concat((input ?? string.Empty).Select((x, i) => i > 0 && char.IsUpper(x) && !char.IsUpper(input[i - 1]) ? $"_{x}" : x.ToString())).ToLower();
    }

    /*
     * def validate_class(class_name: str):
    if class_name not in valid_classes:
        raise ValueError(f"ERROR: {class_name} not on list of valid classes")


def parse_classes(raw: str) -> Dict[str, int]:
    """
    the class field is 1 or more pairs of the format
    Class1(/Class2)? [0-9] separated by commas
    :param raw: the raw field from the CSV
    :return: A list of class/level pairs
    """
    ret: Dict[str, int] = {}

    for classes_level in raw.split(','):
        class_name, spell_level = classes_level.split(' ')
        if '/' in class_name:
            class1, class2 = class_name.split('/')
            validate_class(class1)
            validate_class(class2)
            ret[class1] = spell_level
            ret[class2] = spell_level
        else:
            validate_class(class_name)
            ret[class_name] = spell_level

    return ret

def parse_components(raw: str) ->

     */
}
