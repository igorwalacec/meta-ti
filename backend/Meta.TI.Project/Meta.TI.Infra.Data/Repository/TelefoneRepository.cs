using System.Linq;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;
using Meta.TI.Infra.Data.Context;

namespace Meta.TI.Infra.Data.Repository
{
    public class TelefoneRepository : Repository<Telefone>, ITelefoneRepository
    {
        public TelefoneRepository(MetaTiContext context) : base(context)
        {
        }
        public Telefone ObterTelefone(int Id)
        {
            return DbSet.FirstOrDefault(x => x.Id == Id);
        }
    }
}
