// See https://aka.ms/new-console-template for more information
using api.Models.Database;

using AutoMapper;

namespace Data_Helper;

internal class Program
{
    static async Task Main(string[] args)
    {
        // maybe someday i'll make this great. for now it's gonna suck :)
        string spellCsv = args.First();
        if (!File.Exists(spellCsv))
        {
            Console.Error.WriteLine($"Unable to find or access ${spellCsv}");
            System.Environment.Exit(1);
        }

        var csvSpells = await SpellImporter.ImportSpellFromCsv(spellCsv);

        var mapper   = GetMapperConfig().CreateMapper();
        var dbSpells = mapper.Map<IEnumerable<Spell>>(csvSpells);
        
        Console.WriteLine($"Found and imported {csvSpells.Count()} spells.");
    }

    private static MapperConfiguration GetMapperConfig()
    {
        return new MapperConfiguration(cfg =>
                                           cfg.CreateMap<CsvSpell, Spell>()
        );
    }
}