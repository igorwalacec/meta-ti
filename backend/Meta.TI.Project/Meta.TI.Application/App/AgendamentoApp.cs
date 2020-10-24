using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Meta.TI.Application.Interfaces;
using Meta.TI.Application.ViewModels;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Handlers;

namespace Meta.TI.Application.App
{
    public class AgendamentoApp : IAgendamentoApp
    {
        private readonly AgendamentoHandler handler;
        private readonly IMapper mapper;

        public AgendamentoApp(AgendamentoHandler _handler, IMapper _mapper)
        {
            handler = _handler;
            mapper = _mapper;
        }

        public GenericCommandResult AlterarAgendamento(AlterarAgendamentoCommand command)
        {
            var result = (GenericCommandResult)handler.Handle(command);

            if (result.Sucess)
            {
                result.Data = mapper.Map<AgendamentoViewModel>(result.Data);
            }
            return result;
        }

        public GenericCommandResult ConsultarAgendamentoPorId(ConsultarAgendamentoPorIdCommand command)
        {
            var result = (GenericCommandResult)handler.Handle(command);

            if (result.Sucess)
            {
                result.Data = mapper.Map<AgendamentoViewModel>(result.Data);
            }
            return result;
        }

        public GenericCommandResult ConsultarAgendamentoPorIdUsuario(ConsultarAgendamentoPorIdUsuarioCommand command)
        {
            var result = (GenericCommandResult)handler.Handle(command);

            if (result.Sucess)
            {
                result.Data = mapper.Map<List<AgendamentoViewModel>>(result.Data);
            }
            return result;
        }

        public GenericCommandResult CriacaoAgendamento(CriacaoAgendamentoCommand command)
        {
            var result = (GenericCommandResult)handler.Handle(command);

            if (result.Sucess)
            {
                result.Data = mapper.Map<AgendamentoViewModel>(result.Data);
            }
            return result;
        }

        public GenericCommandResult DeletarAgendamento(DeletarAgendamentoCommand command)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
