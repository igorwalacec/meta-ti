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
    public class EnderecoApp : IEnderecoApp
    {
        private readonly IMapper mapper;
        private readonly IEnderecoRepository enderecoRepository;
        private readonly UsuarioHandler usuarioHandler;
        private readonly HemocentroHandler hemocentroHandler;
        public EnderecoApp(IMapper _mapper, IEnderecoRepository _enderecoRepository, UsuarioHandler _usuarioHandler, HemocentroHandler _hemocentroHandler)
        {
            mapper = _mapper;
            enderecoRepository = _enderecoRepository;
            usuarioHandler = _usuarioHandler;
            hemocentroHandler = _hemocentroHandler;
        }

        public GenericCommandResult AlterarEnderecoUsuario(AlterarEnderecoUsuarioCommand comando)
        {
            var result = (GenericCommandResult)usuarioHandler.Handle(comando);

            if (result.Sucess)
            {
                result.Data = mapper.Map<UsuarioViewModel>(result.Data);
            }
            return result;
        }

        public GenericCommandResult AlterarEnderecoHemocentro(AlterarEnderecoHemocentroCommand comando)
        {
            var result = (GenericCommandResult)hemocentroHandler.Handle(comando);

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
