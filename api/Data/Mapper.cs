using api.Models.Database;
using api.Models.Response;

using AutoMapper;

namespace api.Data;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<Spell, SpellResponse>();
        CreateMap<Descriptor, string>()?.ConstructUsing(d => d.Name);
        CreateMap<SourceMaterial, SourceMaterialResponse>();

        CreateMap<ClassLevel, KeyValuePair<Class, int>>().ConstructUsing(cl => new KeyValuePair<Class, int>(cl.Class, cl.Level));
    }
}
