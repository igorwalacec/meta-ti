using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Application.ViewModels;
using Meta.TI.Domain.Commands;

namespace Meta.TI.Application.Interfaces
{
    public interface IUsuarioApp : IDisposable
    {
        GenericCommandResult CriarUsuario(CriacaoUsuarioCommand comando);
        GenericCommandResult GetToken(TokenCommand comando);
    }
}
