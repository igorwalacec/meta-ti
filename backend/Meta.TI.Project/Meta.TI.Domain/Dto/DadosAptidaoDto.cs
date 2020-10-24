using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Domain.Dto
{
    public class DadosAptidaoDto
    {
        public DateTime DataResultado { get; set; }
        public int IdResposta { get; set; }
        public bool Resposta { get; set; }
        public int DiasAfastados { get; set; }
        public DateTime DataProximaDoacao { get; set; }
        public int IdStatus { get; set; }
    }
}
