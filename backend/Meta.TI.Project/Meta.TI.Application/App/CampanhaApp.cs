using System;
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

        public GenericCommandResult ObterTodasCampanhas()
        {
            var result = (GenericCommandResult)handler.Handle();

            if (result.Sucess)
            {
                result.Data = mapper.Map<CampanhaViewModel>(result.Data);
            }
            return result;
        }

        public GenericCommandResult ObterCampanhaPorHemocentro(Guid idHemocentro)
        {
            var result = (GenericCommandResult)handler.Handle(idHemocentro);

            if (result.Sucess)
            {
                result.Data = mapper.Map<CampanhaViewModel>(result.Data);
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


        public GenericCommandResult DeletarCampanha(int idCampanha)
        {
            return (GenericCommandResult)handler.Handle(idCampanha);
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
