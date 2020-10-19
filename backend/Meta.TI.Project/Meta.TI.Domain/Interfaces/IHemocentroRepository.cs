using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Models;

namespace Meta.TI.Domain.Interfaces
{
    public interface IHemocentroRepository : IRepository<Hemocentro>
    {
        bool VerificarExistenciaCNPJ(string cnpj);
        Hemocentro ObterHemocentroPorId (Guid guid);
        List<Hemocentro> ObterTodosHemocentro();
    }
}
