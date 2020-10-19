using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Meta.TI.Application.Interfaces;
using Meta.TI.Application.ViewModels;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Handlers;
using Meta.TI.Domain.Interfaces;

namespace Meta.TI.Application.App
{
    public class TelefoneApp : ITelefoneApp
    {
        private readonly IMapper mapper;
        private readonly ITelefoneRepository telefoneRepository;
        private readonly HemocentroHandler handler;
        public TelefoneApp(ITelefoneRepository _telefoneRepository, IMapper _mapper, HemocentroHandler _handler)
        {
            telefoneRepository = _telefoneRepository;
            mapper = _mapper;
            handler = _handler;
        }

        public GenericCommandResult AlterarTelefoneHemocentro(AlterarTelefoneHemocentroCommand comando)
        {
            return (GenericCommandResult)handler.Handle(comando);
        }
    }
}
