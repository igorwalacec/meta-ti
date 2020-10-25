using System;
using System.Collections.Generic;
using AutoMapper;
using Meta.TI.Application.Interfaces;
using Meta.TI.Application.ViewModels;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Handlers;

namespace Meta.TI.Application.App
{
    public class CampanhaApp : ICampanhaApp
    {
        private readonly CampanhaHandler handler;
        private readonly IMapper mapper;

        public CampanhaApp(CampanhaHandler _handler, IMapper _mapper)
        {
            handler = _handler;
            mapper = _mapper;
        }

        public GenericCommandResult ObterTodasCampanhas(ConsultarCampanhaCommand command)
        {
            var result = (GenericCommandResult)handler.Handle(command);

            if (result.Sucess)
            {
                result.Data = mapper.Map<List<CampanhaViewModel>>(result.Data);
            }
            return result;
        }

        public GenericCommandResult ObterCampanhaPorHemocentro(ConsultarCampanhaPorHemocentroCommand command)
        {
            var result = (GenericCommandResult)handler.Handle(command);

            if (result.Sucess)
            {
                result.Data = mapper.Map<List<CampanhaViewModel>>(result.Data);
            }
            return result;
        }
        public GenericCommandResult CriacaoCampanha(CriacaoCampanhaCommand command)
        {
            var result = (GenericCommandResult)handler.Handle(command);

            if (result.Sucess)
            {
                result.Data = mapper.Map<CampanhaViewModel>(result.Data);
            }
            return result;
        }
    
        public GenericCommandResult AlterarCampanha(AlterarCampanhaCommand command)
        {
            var result = (GenericCommandResult)handler.Handle(command);

            if (result.Sucess)
            {
                result.Data = mapper.Map<CampanhaViewModel>(result.Data);
            }
            return result;
        }


        public GenericCommandResult DeletarCampanha(DeletarCampanhaCommand command)
        {
            return (GenericCommandResult)handler.Handle(command);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
