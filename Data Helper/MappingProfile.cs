using api.Models.Database;

using AutoMapper;

namespace Data_Helper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CsvSpell, Spell>()
           .ForMember(
                dest => dest.HasCostlyComponents,
                opt => opt.MapFrom(src => src.CostlyComponents)
            )
           .ForMember(
                dest => dest.ComponentDetails,
                opt => opt.MapFrom(src => src.Components))
           .ForMember(
                dest => dest.IsDismissable,
                opt => opt.MapFrom(src => src.Dismissible))
           .ForMember(
                dest => dest.IsShapeable,
                opt => opt.MapFrom(src => src.Shapeable))
           .ForMember(
                dest => dest.HasVerbalComponent,
                opt => opt.MapFrom(src => src.Verbal))
           .ForMember(
                dest => dest.HasSomaticComponent,
                opt => opt.MapFrom(src => src.Somatic))
           .ForMember(
                dest => dest.HasMaterialComponent,
                opt => opt.MapFrom(src => src.Material))
            ;

        CreateMap<string, SourceMaterial>()
           .ConstructUsing(s => new SourceMaterial
            {
                Name = s,
            });

    }
}
