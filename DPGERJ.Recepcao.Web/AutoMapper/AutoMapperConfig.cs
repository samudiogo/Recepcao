﻿using AutoMapper;
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
            CreateMap<Destino, DestinoViewModel>();
            CreateMap<Assistido, AssistidoViewModel>();
            CreateMap<Visita, VisitaViewModel>();
        }
    }


    public class ViewModelToDomainMappingProfile : Profile
    {

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<DestinoViewModel, Destino>();
            CreateMap<AssistidoViewModel, Assistido>();
            CreateMap<VisitaViewModel, Visita>();

        }

    }
}