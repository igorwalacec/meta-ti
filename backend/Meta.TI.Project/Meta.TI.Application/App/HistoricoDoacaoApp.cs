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
    public class HistoricoDoacaoApp : IHistoricoDoacaoApp
    {
        private readonly UsuarioHandler handler;
        private readonly IMapper mapper;
        public HistoricoDoacaoApp(UsuarioHandler _handler, IMapper _mapper)
        {
            handler = _handler;
            mapper = _mapper;
        }

        public GenericCommandResult CadastrarNovaDoacao(CadastrarNovaDoacaoCommand comando)
        {
            var result = (GenericCommandResult)handler.Handle(comando);

            if (result.Sucess)
            {
                result.Data = mapper.Map<HistoricoDoacaoViewModel>(result.Data);
            }
            return result;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
