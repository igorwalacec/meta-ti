using System;
using Meta.TI.Domain.Models;

namespace Meta.TI.Domain.Interfaces
{
    public interface IExpedienteRepository : IRepository<Expediente>
    {
        Expediente ObterExpediente(Guid idHemocentro, int idDiaSemana);
    }
}
