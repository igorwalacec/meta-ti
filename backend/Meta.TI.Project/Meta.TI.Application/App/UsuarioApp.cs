using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Meta.TI.Application.Interfaces;
using Meta.TI.Application.ViewModels;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Handlers;
using Meta.TI.Domain.Models;

namespace Meta.TI.Application.App
{
    public class UsuarioApp : IUsuarioApp
    {
        private readonly UsuarioHandler handler;
        private readonly IMapper mapper;
        public UsuarioApp(UsuarioHandler _handler, IMapper _mapper)
        {
            handler = _handler;
            mapper = _mapper;
        }

        public GenericCommandResult CriarUsuario(CriacaoUsuarioCommand comando)
        {

            var result = (GenericCommandResult)handler.Handle(comando);

            if(result.Sucess)
            {
                result.Data = mapper.Map<UsuarioViewModel>(result.Data);
            }
            return result;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public GenericCommandResult GetToken(TokenCommand comando)
        {
            return (GenericCommandResult)handler.Handle(comando);
        }

        public GenericCommandResult ObterUsuarioPorId(ObterUsuarioPorIdCommand comando)
        {
            var result = (GenericCommandResult)handler.Handle(comando);

            if (result.Sucess)
            {
                result.Data = mapper.Map<UsuarioViewModel>(result.Data);
            }
            return result;
        }
    }
}
