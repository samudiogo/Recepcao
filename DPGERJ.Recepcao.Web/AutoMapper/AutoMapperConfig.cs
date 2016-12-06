using AutoMapper;
using DPGERJ.Recepcao.Domain.Entities;
using DPGERJ.Recepcao.Web.ViewModels;

namespace DPGERJ.Recepcao.Web.AutoMapper
{
    public class AutoMapperConfig
    {
        public static IMapper Mapper { get; private set; }

        public static void RegisterMappings()
        {
            Mapper = new Mapper(new MapperConfiguration((cfg) =>
           {

               cfg.CreateMap<Destino, DestinoViewModel>()
                .ForMember(dest => dest.Id, origem => origem.MapFrom(src => src.DestinoId))
                .ReverseMap();

               cfg.CreateMap<Assistido, AssistidoViewModel>()
                   .PreserveReferences()
                   .ReverseMap();

               cfg.CreateMap<Visita, VisitaViewModel>()
                   .ForMember(destino => destino.AssistidoId, origem => origem.MapFrom(src => src.AssistidoId))
                   .PreserveReferences()
                   .ReverseMap();
           }));
        }
    }

    

}