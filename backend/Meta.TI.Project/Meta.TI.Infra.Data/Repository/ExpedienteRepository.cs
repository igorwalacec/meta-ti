using System.Linq;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;
using Meta.TI.Infra.Data.Context;

namespace Meta.TI.Infra.Data.Repository
{
    public class ExpedienteRepository : Repository<Expediente>, IExpedienteRepository
    {
        public ExpedienteRepository(MetaTiContext context) : base(context)
        {
        }
        public Expediente ObterExpediente(int Id)
        {
            return DbSet.FirstOrDefault(x => x.Id == Id);
        }
    }
}
