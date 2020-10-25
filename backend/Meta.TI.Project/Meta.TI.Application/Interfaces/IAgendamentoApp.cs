using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Commands;

namespace Meta.TI.Application.Interfaces
{
    public interface IAgendamentoApp : IDisposable
    {
        GenericCommandResult ConsultarAgendamentoPorId(ConsultarAgendamentoPorIdCommand command);
        GenericCommandResult ConsultarAgendamentoPorIdUsuario(ConsultarAgendamentoPorIdUsuarioCommand command);
        GenericCommandResult CriacaoAgendamento(CriacaoAgendamentoCommand command);
        GenericCommandResult AlterarAgendamento(AlterarAgendamentoCommand command);
        GenericCommandResult DeletarAgendamento(DeletarAgendamentoCommand command);
    }
}
