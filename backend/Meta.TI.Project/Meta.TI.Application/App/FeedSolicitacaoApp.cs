using System;
using System.Collections.Generic;
using AutoMapper;
using Meta.TI.Application.Interfaces;
using Meta.TI.Application.ViewModels;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Handlers;

namespace Meta.TI.Application.App
{
    public class FeedSolicitacaoApp : IFeedSolicitacaoApp
    {
        private readonly FeedSolicitacaoHandler handler;
        private readonly IMapper mapper;

        public FeedSolicitacaoApp(FeedSolicitacaoHandler _handler, IMapper _mapper)
        {
            handler = _handler;
            mapper = _mapper;
        }

        public GenericCommandResult ObterTodosFeedSolicitacao(ConsultarFeedSolicitacaoCommand command)
        {
            var result = (GenericCommandResult)handler.Handle(command);

            if (result.Sucess)
            {
                result.Data = mapper.Map<List<FeedSolicitacaoViewModel>>(result.Data);
            }
            return result;
        }

        public GenericCommandResult ObterFeedSolicitacaoPorHemocentro(ConsultarFeedSolicitacaoPorHemocentroCommand command)
        {
            var result = (GenericCommandResult)handler.Handle(command);

            if (result.Sucess)
            {
                result.Data = mapper.Map<List<FeedSolicitacaoViewModel>>(result.Data);
            }
            return result;
        }

        public GenericCommandResult ObterFeedSolicitacaoPorTipoSanguineo(ConsultarFeedSolicitacaoPorTipoSanguineoCommand command)
        {
            var result = (GenericCommandResult)handler.Handle(command);

            if (result.Sucess)
            {
                result.Data = mapper.Map<List<FeedSolicitacaoViewModel>>(result.Data);
            }
            return result;
        }

        public GenericCommandResult CriacaoFeedSolicitacao(CriacaoFeedSolicitacaoCommand command)
        {
            var result = (GenericCommandResult)handler.Handle(command);

            if (result.Sucess)
            {
                result.Data = mapper.Map<FeedSolicitacaoViewModel>(result.Data);
            }
            return result;
        }

        public GenericCommandResult AlterarFeedSolicitacao(AlterarFeedSolicitacaoCommand command)
        {
            var result = (GenericCommandResult)handler.Handle(command);

            if (result.Sucess)
            {
                result.Data = mapper.Map<FeedSolicitacaoViewModel>(result.Data);
            }
            return result;
        }

        public GenericCommandResult DeletarFeedSolicitacao(DeletarFeedSolicitacaoCommand command)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
