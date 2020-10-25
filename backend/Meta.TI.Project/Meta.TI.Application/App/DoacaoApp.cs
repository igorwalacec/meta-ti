using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Meta.TI.Application.Interfaces;
using Meta.TI.Application.ViewModels;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Handlers;
using Meta.TI.Domain.Interfaces;

namespace Meta.TI.Application.App
{
    public class DoacaoApp : IDoacaoApp
    {
        private readonly UsuarioHandler handler;
        private readonly IMapper mapper;
        private readonly IHistoricoDoacaoRepository historicoDoacaoRepository;
        private readonly IOrientacaoDoacaoRepository orientacaoDoacaoRepository;

        public DoacaoApp(UsuarioHandler _handler, IMapper _mapper, IHistoricoDoacaoRepository _historicoDoacaoRepository, IOrientacaoDoacaoRepository _orientacaoDoacaoRepository)
        {
            handler = _handler;
            mapper = _mapper;
            historicoDoacaoRepository = _historicoDoacaoRepository;
            orientacaoDoacaoRepository = _orientacaoDoacaoRepository;
        }

        public GenericCommandResult CadastrarNovaDoacao(CadastrarNovaDoacaoCommand comando)
        {
            var result = (GenericCommandResult)handler.Handle(comando);

            if (result.Sucess)
            {
                result.Data = mapper.Map<HistoricoDoacaoViewModel>(result.Data);
            }
            return result;
        }

        public GenericCommandResult ObterHistoricoDoacao(Guid idUsuario)
        {
            var historicoDoacao = historicoDoacaoRepository.ObterDoacaoPorId(idUsuario).ProjectTo<HistoricoDoacaoViewModel>(mapper.ConfigurationProvider);

            return new GenericCommandResult(true, historicoDoacao);
        }

        public GenericCommandResult ObterOrientacoesDoacao()
        {
            return new GenericCommandResult(true, orientacaoDoacaoRepository.ObterTodos().ProjectTo<OrientacaoDoacaoViewModel>(mapper.ConfigurationProvider));
        }

        public GenericCommandResult BuscarStatusDoacao(StatusDoacaoCommand idUsuario)
        {
            var result = (GenericCommandResult)handler.Handle(idUsuario);

            return result;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }        
    }
}
