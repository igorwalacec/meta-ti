using Meta.TI.Domain.Models;

namespace Meta.TI.Domain.Interfaces
{
    public interface ITelefoneRepository : IRepository<Telefone>
    {
        Telefone ObterTelefone(int Id);
    }
}
