using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Meta.TI.Application.Interfaces;
using Meta.TI.Application.ViewModels;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Handlers;
using Meta.TI.Domain.Interfaces;

namespace Meta.TI.Application.App
{
    public class AptidaoApp : IAptidaoApp
    {
        private readonly IMapper mapper;
        private readonly IQuestoesAptidaoRepository questoesAptidaoRepository;
        private readonly DadosAptidaoHandler dadosAptidaoHandler;
        private readonly UsuarioHandler usuarioHandler;

        public AptidaoApp(IMapper _mapper, IQuestoesAptidaoRepository _questoesAptidaoRepository, DadosAptidaoHandler _dadosAptidaoHandler, UsuarioHandler _usuarioHandler)
        {
            mapper = _mapper;
            questoesAptidaoRepository = _questoesAptidaoRepository;
            dadosAptidaoHandler = _dadosAptidaoHandler;
            usuarioHandler = _usuarioHandler;
        }        

        public GenericCommandResult ObterQuestoesAptidao()
        {
            return new GenericCommandResult(true, questoesAptidaoRepository.ObterTodos().ProjectTo<QuestoesAptidaoViewModel>(mapper.ConfigurationProvider));
        }

        public GenericCommandResult CadastrarRespostasAptidao(RespostaAptidaoCommand respostasAptidao)
        {
            var result = (GenericCommandResult)dadosAptidaoHandler.Handle(respostasAptidao);

            if (result.Sucess)
            {
                result.Data = mapper.Map<UsuarioViewModel>(result.Data);
            }
            return result;
        }

        public GenericCommandResult CalcularDayOff(StatusDoacaoCommand usuarioId)
        {
            var result = (GenericCommandResult)usuarioHandler.Handle(usuarioId);

            return result;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }        
    }
}
