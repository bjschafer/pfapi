using System.Text.Json;

namespace api.Data;

public static class Helpers
{
    /// <summary>
    ///     Reads a list from a JSON file and returns a list of the objects therein.
    /// </summary>
    /// <param name="filename">JSON filename without suffix.</param>
    /// <param name="baseDirectory">Where to look for the filename; default ./Data/Seed/</param>
    /// <typeparam name="T">Type to deserialize into</typeparam>
    /// <returns>a list (may be empty) of the desired object.</returns>
    public static List<T> GetSeedData<T>(string filename, string baseDirectory = "Data/Seed/") where T : class
    {
        var filepath = Path.Combine(baseDirectory, $"{filename}.json");

        var contents = File.ReadAllText(filepath);
        var seeds = JsonSerializer.Deserialize<List<T>>(contents);

        return seeds ?? [];
    }
}
