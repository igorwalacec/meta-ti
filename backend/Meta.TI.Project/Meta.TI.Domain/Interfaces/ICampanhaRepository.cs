using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Models;

namespace Meta.TI.Domain.Interfaces
{
    public interface ICampanhaRepository : IRepository<Campanha>
    {
        List<Campanha> ObterTodasCampanhas(DateTime dataAtual);
        List<Campanha> ObterCampanhaPorHemocentro(DateTime dataAtual, Guid idHemocentro);
        List<Campanha> ExtracaoCampanhasParaNotificacoes(int idCidade);
        Campanha ObterCampanhaPorId(int id);
        Campanha ObterCampanhaCriada(Guid idHemocentro);
    }
}
