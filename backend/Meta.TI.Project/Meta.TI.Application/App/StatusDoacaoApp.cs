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
    public class StatusDoacaoApp : IStatusDoacaoApp
    {
        private readonly IMapper mapper;
        private readonly UsuarioHandler handler;

        public StatusDoacaoApp(IMapper _mapper, UsuarioHandler _handler)
        {
            mapper = _mapper;
            handler = _handler;
        }

        public GenericCommandResult BuscarStatusDoacao(StatusDoacaoCommand idUsuario)
        {
            var result = (GenericCommandResult)handler.Handle(idUsuario);

            if (result.Sucess)
            {
                result.Data = mapper.Map<HistoricoAptidaoViewModel>(result.Data);
            }
            return result;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
