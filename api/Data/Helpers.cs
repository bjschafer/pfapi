using System.Text.Json;

using api.Models;

namespace api.Data;

public static class Helpers
{
    /// <summary>
    /// Reads a list from a JSON file and returns a list of the objects therein.
    /// </summary>
    /// <param name="filename">JSON filename without suffix.</param>
    /// <param name="baseDirectory">Where to look for the filename; default ./Data/Seed/</param>
    /// <typeparam name="T">Anything marked as ISeedable</typeparam>
    /// <returns>a list (may be empty) of the desired object.</returns>
    public static List<T> GetSeedData<T>(string filename, string baseDirectory = "Data/Seed/") where T : ISeedable
    {
        string filepath = Path.Combine(baseDirectory, $"{filename}.json");
        List<T>? seeds;

        string contents = File.ReadAllText(filepath);
        seeds = JsonSerializer.Deserialize<List<T>>(contents);

        return seeds ?? new List<T>();
    }
}
