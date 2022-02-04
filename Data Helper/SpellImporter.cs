using System.Globalization;

using api.Models.Database;

using CsvHelper;
using CsvHelper.Configuration;

namespace Data_Helper;

public static class SpellImporter
{
    /// <summary>
    /// the descriptor field is 0 or more words separated by commas
    /// </summary>
    /// <param name="raw">the raw field from the CSV</param>
    /// <returns>a List of descriptors</returns>
    public static List<Descriptor> ParseDescriptors(string raw)
    {
        List<Descriptor> ret = new();
        foreach (string segment in raw.Split(','))
        {
            ret.Add(new Descriptor()
            {
                Name = segment.Trim(),
            });
        }

        return ret;
    }

    /// <summary>
    /// Takes a CSV file from the SRD and converts it into representative objects
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
        string fileText = await File.ReadAllTextAsync(filepath);
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
