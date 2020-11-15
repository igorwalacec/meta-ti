using System;
using System.Collections.Generic;
using Meta.TI.Domain.Models;

namespace Meta.TI.Domain.Interfaces
{
    public interface IEstoqueSanguineoRepository : IRepository<EstoqueSanguineo>
    {
        List<EstoqueSanguineo> ObterTodosEstoqueSanguineo(Guid idHemocentro);
        List<EstoqueSanguineo> ExtracaoEstoqueSanguineoParaNotificacoes(int idCidade, int? idTipoSanguineo);
        EstoqueSanguineo ObterEstoqueSanquineoPorTipo(Guid idHemocentro, int idTipoSanguineo);
    }
}
