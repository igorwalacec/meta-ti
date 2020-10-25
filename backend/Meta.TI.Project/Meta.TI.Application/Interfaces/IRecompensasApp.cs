using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Commands;

namespace Meta.TI.Application.Interfaces
{
    public interface IRecompensasApp : IDisposable
    {
        GenericCommandResult ListarPatrocinador();
        GenericCommandResult AdicionarPatrocinador(AdicionarPatrocinadorCommand comando);
        GenericCommandResult DesativarPatrocinadorPorId(DesativarPatrocinadorPorIdCommand comando);

        GenericCommandResult ListarRecompensas();
        GenericCommandResult AdicionarRecompensas(AdicionarRecompensasCommand comando);
        GenericCommandResult DesativarRecompensasPorId(DesativarRecompensasPorIdCommand comando);

        GenericCommandResult ListarLevel();
        GenericCommandResult AdicionarLevel(AdicionarLevelCommand comando);
        GenericCommandResult DesativarLevelPorId(DesativarLevelPorIdCommand comando);
    }
}
