using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Models;

namespace Meta.TI.Domain.Interfaces
{
    public interface IAgendamentoRepository : IRepository<Agendamento>
    {
        Agendamento ObterAgendamentoPorId(Guid id);
        List<Agendamento> ObterAgendamentoPorUsuario(Guid idUsuario);
        bool VerificarAgendamentoPorUsuario(Usuario usuario);
    }
}
