using System;
using AutoMapper;
using Meta.TI.Application.Interfaces;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Handlers;
using Meta.TI.Domain.Interfaces;

namespace Meta.TI.Application.App
{
    public class EstoqueSanguineoApp : IEstoqueSanguineoApp
    {
        private readonly IMapper mapper;
        private readonly IEstoqueSanguineoRepository estoqueSanquineoRepository;
        private readonly HemocentroHandler handler;
        public EstoqueSanguineoApp(IEstoqueSanguineoRepository _estoqueSanquineoRepository, IMapper _mapper, HemocentroHandler _handler)
        {
            estoqueSanquineoRepository = _estoqueSanquineoRepository;
            mapper = _mapper;
            handler = _handler;
        }
        public GenericCommandResult ObterTodosEstoqueSanguineo(ConsultarEstoqueSanguineoPorHemocentroCommand command)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        public GenericCommandResult ObterEstoqueSanquineoPorTipo(ConsultarEstoqueSanquineoCommand comando)
        {
            return (GenericCommandResult)handler.Handle(comando);
        }

        public GenericCommandResult AlterarEstoqueSanguineo(AlterarEstoqueSanguineoCommand comando)
        {
            return (GenericCommandResult)handler.Handle(comando);
        }
    }
}
