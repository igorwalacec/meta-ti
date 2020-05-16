using Meta.TI.Domain.Entities;
using Meta.TI.Domain.Repositories;
using Meta.TI.Infra.Context;

namespace Meta.TI.Infra.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(MetaTiContext context) : base(context)
        {
        }
    }
}