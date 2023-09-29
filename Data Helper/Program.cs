// See https://aka.ms/new-console-template for more information
using RestSharp;

namespace Data_Helper;

internal class Program
{
    private static readonly string apiBase = "http://localhost:5252/api";
    // private static readonly string _api_base = "https://pfapi.cmdcentral.xyz/api";
    private static async Task Main(string[] args)
    {
        // maybe someday i'll make this great. for now it's gonna suck :)
        var spellCsv = args.First();
        if (!File.Exists(spellCsv))
        {
            Console.Error.WriteLine($"Unable to find or access {spellCsv}");
            Environment.Exit(1);
        }

        var csvSpells = await SpellImporter.ImportSpellFromCsv(spellCsv);

        // var mapper   = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()).CreateMapper();
        // var dbSpells = mapper.Map<IEnumerable<Spell>>(csvSpells);
        //
        // Console.WriteLine($"Found and imported {csvSpells.Count()} spells.");

        var spellsAsJson = csvSpells.Select(c => c.ToApiJsonObject());
        await PostToApi(spellsAsJson);
    }

    private static async Task PostToApi(IEnumerable<string> spellsAsJson)
    {
        var client = new RestClient(apiBase);

        foreach (var spell in spellsAsJson)
        {
            Console.WriteLine(spell);
            var request = new RestRequest("Spell");
            request.AddStringBody(spell, ContentType.Json);
            await client.PostAsync(request);
        }
    }
}
