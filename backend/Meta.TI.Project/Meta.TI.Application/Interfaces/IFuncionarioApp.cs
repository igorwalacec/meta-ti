using System;
using Meta.TI.Domain.Commands;

namespace Meta.TI.Application.Interfaces
{
    public interface IFuncionarioApp : IDisposable
    {

        GenericCommandResult CriarFuncionario(CriacaoFuncionarioCommand comando);
        GenericCommandResult GetToken(TokenCommand comando);
    }
}
