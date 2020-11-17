using System;
using System.Collections.Generic;
using Meta.TI.Domain.Models;

namespace Meta.TI.Domain.Interfaces
{
    public interface IExpedienteRepository : IRepository<Expediente>
    {
        Expediente ObterExpediente(Guid idHemocentro, int idDiaSemana);
        List<Expediente> ObterExpedientePorIdHemocentro(Guid idHemocentro);
    }
}
