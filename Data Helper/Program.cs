// See https://aka.ms/new-console-template for more information
using api.Models.Database;

using AutoMapper;

namespace Data_Helper;

internal class Program
{
    private static async Task Main(string[] args)
    {
        // maybe someday i'll make this great. for now it's gonna suck :)
        var spellCsv = args.First();
        if (!File.Exists(spellCsv))
        {
            Console.Error.WriteLine($"Unable to find or access ${spellCsv}");
            Environment.Exit(1);
        }

        var csvSpells = await SpellImporter.ImportSpellFromCsv(spellCsv);

        // var mapper   = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()).CreateMapper();
        // var dbSpells = mapper.Map<IEnumerable<Spell>>(csvSpells);
        //
        // Console.WriteLine($"Found and imported {csvSpells.Count()} spells.");

        IEnumerable<string> spellsAsJson = csvSpells.Select(c => c.ToApiJsonObject());
        
        Console.WriteLine(spellsAsJson.FirstOrDefault());
    }
    
}
