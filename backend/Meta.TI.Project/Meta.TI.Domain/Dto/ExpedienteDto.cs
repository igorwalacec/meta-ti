using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Domain.Dto
{
    public class ExpedienteDto
    {
        public int IdDiaSemana { get; set; }
        public Guid IdHemocentro { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
    }
}
