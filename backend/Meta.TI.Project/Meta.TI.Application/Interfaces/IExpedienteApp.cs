using Meta.TI.Domain.Commands;

namespace Meta.TI.Application.Interfaces
{
    public interface IExpedienteApp
    {
        GenericCommandResult AlterarExpedienteHemocentro(AlterarExpedienteHemocentroCommand comando);
        GenericCommandResult ObterExpedientePorHemocentro(ObterExpedientePorIdHemocentroCommand comando);
    }
}
