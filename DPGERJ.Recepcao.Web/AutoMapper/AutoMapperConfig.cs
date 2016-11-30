using System.Collections.Generic;
using System.Linq;
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
            AutoMapperConfig.Mapper = new Mapper(new MapperConfiguration((mappper) =>
           {
               mappper.AddProfile<ViewModelToDomainMappingProfile>();
               mappper.AddProfile<DomainToViewModelMappingProfile>();

           }));
        }
    }

    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Destino, DestinoViewModel>()
                .ForMember(dest => dest.Id, origem => origem.MapFrom(src => src.DestinoId));
            CreateMap<Assistido, AssistidoViewModel>()
                .PreserveReferences();
                //.ForMember(destino => destino.Visitas, origem => origem.ResolveUsing(src => src.Visitas));
               // .ReverseMap();
                
            CreateMap<Visita, VisitaViewModel>();
            //.ForMember(destino => destino.IdAssistido, 
            //origem => origem.MapFrom(src=> src.));
        }
    }


    public class ViewModelToDomainMappingProfile : Profile
    {

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<DestinoViewModel, Destino>().ForMember(dest => dest.DestinoId, origem => origem.MapFrom(src => src.Id)); ;
            CreateMap<AssistidoViewModel, Assistido>();
            CreateMap<VisitaViewModel, Visita>();

        }

    }
}