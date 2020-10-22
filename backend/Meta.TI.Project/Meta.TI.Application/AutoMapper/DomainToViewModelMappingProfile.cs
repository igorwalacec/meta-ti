using AutoMapper;
using Meta.TI.Application.ViewModels;
using Meta.TI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Estado, EstadoViewModel>();
            CreateMap<Cidade, CidadeViewModel>();
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<TipoSanguineo, TipoSanguineoViewModel>();
            CreateMap<Hemocentro, HemocentroViewModel>();
            CreateMap<Funcionario, FuncionarioViewModel>();
            CreateMap<FeedSolicitacao, FeedSolicitacaoViewModel>();
            CreateMap<Campanha, CampanhaViewModel>();
            CreateMap<Agendamento, AgendamentoViewModel>();
        }
    }
}
