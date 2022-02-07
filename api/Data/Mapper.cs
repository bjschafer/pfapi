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
        CreateMap<Descriptor, string>()
           .ConstructUsing(d => d.Name);
        CreateMap<SourceMaterial, SourceMaterialResponse>();

        // CreateMap<ClassLevel, KeyValuePair<Class, int>>().ConstructUsing(cl => new KeyValuePair<Class, int>(cl.Class, cl.Level));
        CreateMap<ClassSpell, KeyValuePair<string, int>>()
           .ConstructUsing(cs => new KeyValuePair<string, int>(cs.Class.Name, cs.Level));
        
        CreateMap<SpellRequest, Spell>();
        CreateMap<string, Descriptor>()
           .ConstructUsing(s => new Descriptor()
            {
                Name = s,
            });
    }
}
