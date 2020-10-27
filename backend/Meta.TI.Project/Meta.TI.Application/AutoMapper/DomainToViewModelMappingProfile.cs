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
            CreateMap<QuestoesAptidao, QuestoesAptidaoViewModel>();
            CreateMap<HistoricoAptidao, HistoricoAptidaoViewModel>();
            CreateMap<HistoricoDoacao, HistoricoDoacaoViewModel>();
            CreateMap<OrientacaoDoacao, OrientacaoDoacaoViewModel>();
            CreateMap<StatusDoacao, HistoricoAptidaoViewModel>();
            CreateMap<Hemocentro, HemocentroViewModel>();
            CreateMap<Funcionario, FuncionarioViewModel>();
            CreateMap<FeedSolicitacao, FeedSolicitacaoViewModel>();
            CreateMap<Campanha, CampanhaViewModel>();
            CreateMap<Agendamento, AgendamentoViewModel>();
        }
    }
}
