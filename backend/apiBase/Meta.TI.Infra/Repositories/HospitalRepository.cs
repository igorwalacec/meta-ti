using Meta.TI.Domain.Entities;
using Meta.TI.Domain.Repositories;
using Meta.TI.Infra.Context;

namespace Meta.TI.Infra.Repositories
{
    public class HospitalRepository : RepositoryBase<Hospital>, IHospitalRepository
    {
        public HospitalRepository(MetaTiContext context) : base(context)
        {
        }
    }
}