using System;
using AutoMapper;
using Meta.TI.Application.Interfaces;
using Meta.TI.Application.ViewModels;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Handlers;

namespace Meta.TI.Application.App
{
    public class FuncionarioApp : IFuncionarioApp
    {
        private readonly FuncionarioHandler handler;
        private readonly IMapper mapper;
        public FuncionarioApp(FuncionarioHandler _handler, IMapper _mapper)
        {
            handler = _handler;
            mapper = _mapper;
        }

        public GenericCommandResult CriarFuncionario(CriacaoFuncionarioCommand comando)
        {
            var result = (GenericCommandResult)handler.Handle(comando);

            if (result.Sucess)
            {
                result.Data = mapper.Map<FuncionarioViewModel>(result.Data);
            }
            return result;
        }


        public GenericCommandResult GetToken(TokenCommand comando)
        {
            return (GenericCommandResult)handler.Handle(comando);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
