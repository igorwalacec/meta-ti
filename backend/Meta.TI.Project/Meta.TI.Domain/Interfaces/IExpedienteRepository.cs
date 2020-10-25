using Meta.TI.Domain.Models;

namespace Meta.TI.Domain.Interfaces
{
    public interface IExpedienteRepository : IRepository<Expediente>
    {
        Expediente ObterExpediente(int Id);
    }
}
