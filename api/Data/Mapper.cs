using api.Models.Database;
using api.Models.Request;
using api.Models.Response;

using AutoMapper;

namespace api.Data;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<Spell, SpellResponse>();
        CreateMap<ClassLevel, KeyValuePair<string, int>>()
           .ConstructUsing(cl => new KeyValuePair<string, int>(cl.ClassName, cl.Level));
        CreateMap<Descriptor, string>()
           .ConstructUsing(d => d.Name);
        CreateMap<SourceMaterial, SourceMaterialResponse>();
        CreateMap<string, SourceMaterial>()
           .ConstructUsing(s => new SourceMaterial
            {
                Name = s,
            });

        CreateMap<SpellRequest, Spell>();
        CreateMap<KeyValuePair<string, int>, ClassLevel>()
           .ConstructUsing(kvp => new ClassLevel
                {
                    ClassName = kvp.Key,
                    Level     = kvp.Value,
                }
            );
        CreateMap<string, Descriptor>()
           .ConstructUsing(s => new Descriptor
            {
                Name = s,
            });
    }
}
