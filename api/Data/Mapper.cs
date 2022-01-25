using api.Models;

using AutoMapper;

namespace api.Data;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<Spell, SpellResponse>();
        CreateMap<Descriptor, String>().ConstructUsing(d => d.Name);
    }
    
}
