using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class ResultadoAptidao
    {
        public int Id { get; set; }
        public DateTime DataResultado { get; set; }
        public DateTime DataProximaDoacao { get; set; }
        public int DiasAfastados { get; set; }

        public ICollection<RespostasAptidao> RespostasAptidao { get; set; }
        public ICollection<HistoricoAptidao> HistoricoAptidao { get; set; }
    }
}
