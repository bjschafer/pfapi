using System.Text.Json;

using api.Models;

namespace api.Data;

public static class Helpers
{
    public static List<T> GetSeedData<T>(string filename, string baseDirectory = "Data/Seed/") where T : ISeedable
    {
        string filepath = Path.Combine(baseDirectory, $"{filename}.json");
        List<T>? seeds;

        string contents = File.ReadAllText(filepath);
        seeds = JsonSerializer.Deserialize<List<T>>(contents);

        return seeds ?? new List<T>();
    }
}
