using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Meta.TI.Application.Interfaces;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Handlers;
using Meta.TI.Domain.Interfaces;

namespace Meta.TI.Application.App
{
    public class ExpedienteApp : IExpedienteApp
    {
        private readonly IMapper mapper;
        private readonly IExpedienteRepository expedienteRepository;
        private readonly HemocentroHandler handler;
        public ExpedienteApp(IExpedienteRepository _expedienteRepository, IMapper _mapper, HemocentroHandler _handler)
        {
            expedienteRepository = _expedienteRepository;
            mapper = _mapper;
            handler = _handler;
        }

        public GenericCommandResult AlterarExpedienteHemocentro(AlterarExpedienteHemocentroCommand comando)
        {
            return (GenericCommandResult)handler.Handle(comando);
        }
    }
}
