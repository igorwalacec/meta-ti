using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class ResultadoAptidao
    {
        public ResultadoAptidao()
        {

        }
        public ResultadoAptidao(DateTime dataResultado, DateTime dataProximaDoacao, int diasAfastados, int idStatus)
        {
            DataResultado = dataResultado;
            DataProximaDoacao = dataProximaDoacao;
            DiasAfastados = diasAfastados;
            IdStatus = idStatus;
        }

        [Key]
        public int Id { get; set; }
        public DateTime DataResultado { get; set; }
        public DateTime DataProximaDoacao { get; set; }
        public int DiasAfastados { get; set; }
        public int IdStatus { get; set; }

        public ICollection<RespostasAptidao> RespostasAptidao { get; set; }
        public ICollection<HistoricoAptidao> HistoricoAptidao { get; set; }
        public StatusDoacao StatusDoacao { get; set; }
    }
}
