using System;
using System.Collections.Generic;
using Meta.TI.Domain.Models;

namespace Meta.TI.Domain.Interfaces
{
    public interface IEstoqueSanquineoRepository : IRepository<EstoqueSanguineo>
    {
        List<EstoqueSanguineo> ObterTodosEstoqueSanguineo(Guid idHemocentro);

        EstoqueSanguineo ObterEstoqueSanquineoPorTipo(Guid idHemocentro, int idTipoSanguineo);
    }
}
