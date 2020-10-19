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
        private readonly IEstoqueSanquineoRepository estoqueSanquineoRepository;
        private readonly HemocentroHandler handler;
        public EstoqueSanguineoApp(IEstoqueSanquineoRepository _estoqueSanquineoRepository, IMapper _mapper, HemocentroHandler _handler)
        {
            estoqueSanquineoRepository = _estoqueSanquineoRepository;
            mapper = _mapper;
            handler = _handler;
        }
        public GenericCommandResult ObterTodosEstoqueSanguineo(Guid idHemocentro)
        {
            return (GenericCommandResult)handler.Handle(idHemocentro);
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
