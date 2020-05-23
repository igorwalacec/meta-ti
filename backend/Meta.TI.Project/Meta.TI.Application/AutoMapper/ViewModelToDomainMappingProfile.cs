using AutoMapper;
using Meta.TI.Application.ViewModels;
using Meta.TI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<EstadoViewModel, Estado>()
                .ConstructUsing(c => new Estado());
            CreateMap<CidadeViewModel, Cidade>()
                .ConstructUsing(c => new Cidade());
        }
    }
}
