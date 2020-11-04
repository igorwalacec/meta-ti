using System;
using System.Collections.Generic;
using AutoMapper;
using Meta.TI.Application.Interfaces;
using Meta.TI.Application.ViewModels;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Handlers;

namespace Meta.TI.Application.App
{
    public class NotificacoesApp : INotificacoesApp
    {
        private readonly NotificacoesHandler handler;
        private readonly IMapper mapper;

        public NotificacoesApp(NotificacoesHandler _handler, IMapper _mapper)
        {
            handler = _handler;
            mapper = _mapper;
        }

        public GenericCommandResult ConsultarNotificacoesPorIdUsuario(ConsultarNotificacoesPorIdUsuarioCommand command)
        {
            var result = (GenericCommandResult)handler.Handle(command);

            if (result.Sucess)
            {
                result.Data = mapper.Map<List<NotificacoesViewModel>>(result.Data);
            }
            return result;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
