using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Meta.TI.Application.Interfaces;
using Meta.TI.Application.ViewModels;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Handlers;
using Meta.TI.Domain.Interfaces;

namespace Meta.TI.Application.App
{
    public class HistoricoAptidaoApp : IHistoricoAptidaoApp
    {
        private readonly IMapper mapper;
        private readonly IHistoricoAptidaoRepository historicoAptidaoRepository;
        private readonly UsuarioHandler handler;

        public HistoricoAptidaoApp(IMapper _mapper, IHistoricoAptidaoRepository _historicoAptidaoRepository, UsuarioHandler _handler)
        {
            mapper = _mapper;
            historicoAptidaoRepository = _historicoAptidaoRepository;
            handler = _handler;
        }

        public GenericCommandResult CalcularDayOff(Guid usuarioId)
        {
            var result = (GenericCommandResult)handler.Handle(usuarioId);
            if (result.Sucess)
            {
                result.Data = mapper.Map<HistoricoAptidaoViewModel>(result.Data);
            }

            return result;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
