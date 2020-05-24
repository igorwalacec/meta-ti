using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Notifications;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Commands.Contracts;
using Meta.TI.Domain.Handlers.Contracts;

namespace Meta.TI.Domain.Handlers
{
    public class UsuarioHandler : Notifiable,
                            IHandler<CriacaoUsuarioCommand>
    {
        public ICommandResult Handle(CriacaoUsuarioCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }

            return new GenericCommandResult(true, "Usuário cadastrado!", command.Usuario);
        }
    }
}
