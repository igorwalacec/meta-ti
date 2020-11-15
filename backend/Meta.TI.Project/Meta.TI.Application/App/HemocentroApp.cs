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
    public class HemocentroApp : IHemocentroApp
    {
        private readonly HemocentroHandler handler;
        private readonly IMapper mapper;

        public HemocentroApp(HemocentroHandler _handler, IMapper _mapper)
        {
            handler = _handler;
            mapper = _mapper;
        }

        public GenericCommandResult ObterTodosHemocentros()
        {
            var result = (GenericCommandResult)handler.Handle();

            if (result.Sucess)
            {
                result.Data = mapper.Map<List<HemocentroViewModel>>(result.Data);
            }
            return result;
        }

        public GenericCommandResult ObterHemocentroPorId(Guid id)
        {
            var result = (GenericCommandResult)handler.Handle(id);

            if (result.Sucess)
            {
                result.Data = mapper.Map<List<HemocentroViewModel>>(result.Data);
            }
            return result;
        }

        public GenericCommandResult CriarHemocentro(CriacaoHemocentroCommand comando)
        {
            var result = (GenericCommandResult)handler.Handle(comando);

            if (result.Sucess)
            {
                result.Data = mapper.Map<HemocentroViewModel>(result.Data);
            }
            return result;
        }

        public GenericCommandResult AlterarStatusHemocentro(AlterarAtivoHemocentroCommand command)
        {
            var result = (GenericCommandResult)handler.Handle(command);

            if (result.Sucess)
            {
                result.Data = mapper.Map<HemocentroViewModel>(result.Data);
            }
            return result;

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
