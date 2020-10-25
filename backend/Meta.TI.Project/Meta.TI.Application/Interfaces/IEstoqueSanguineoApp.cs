using System;
using Meta.TI.Domain.Commands;

namespace Meta.TI.Application.Interfaces
{
    public interface IEstoqueSanguineoApp
    {
        GenericCommandResult ObterTodosEstoqueSanguineo(ConsultarEstoqueSanguineoPorHemocentroCommand command);

        GenericCommandResult ObterEstoqueSanquineoPorTipo(ConsultarEstoqueSanquineoCommand comando);

        GenericCommandResult AlterarEstoqueSanguineo(AlterarEstoqueSanguineoCommand comando);
    }
}
