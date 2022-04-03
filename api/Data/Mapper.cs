using api.Models.Database;
using api.Models.Request;
using api.Models.Response;

using AutoMapper;

namespace api.Data;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<Spell, SpellResponse>()
           .ForMember(dest => dest.ClassLevels, opt => opt.MapFrom(src => src.ClassSpells));
        CreateMap<ClassSpell, ClassSpellResponse>();
        CreateMap<Descriptor, string>()
           .ConstructUsing(d => d.Name);
        CreateMap<SourceMaterial, SourceMaterialResponse>();
        CreateMap<string, SourceMaterial>()
           .ConstructUsing(s => new()
            {
                Name = s,
            });

        CreateMap<ClassSpellRequest, ClassSpell>();
        CreateMap<SpellRequest, Spell>();
        CreateMap<string, Descriptor>()
           .ConstructUsing(s => new Descriptor()
            {
                Name = s,
            });
    }
}
