using System;
using Meta.TI.Application.Interfaces;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Handlers;

namespace Meta.TI.Application.App
{
    public class CompartilhamentoWhatsappApp : ICompartilhamentoWhatsappApp
    {
        private readonly CompartilhamentoWhatsappHandler handler;

        public CompartilhamentoWhatsappApp(CompartilhamentoWhatsappHandler _handler)
        {
            handler = _handler;
        }

        public GenericCommandResult MontarConvite(CompartilhamentoWhatsappCommand command)
        {
            return (GenericCommandResult)handler.Handle(command);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
