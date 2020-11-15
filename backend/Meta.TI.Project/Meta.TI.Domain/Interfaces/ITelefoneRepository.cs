using System;
using System.Collections.Generic;
using Meta.TI.Domain.Models;

namespace Meta.TI.Domain.Interfaces
{
    public interface ITelefoneRepository : IRepository<Telefone>
    {
        Telefone ObterTelefone(int id);
        List<Telefone> ObterTelefonesPorHemocentro(Guid idHemocentro);
    }
}
