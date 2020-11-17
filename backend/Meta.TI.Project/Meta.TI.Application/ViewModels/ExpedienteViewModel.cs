using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Application.ViewModels
{
    public class ExpedienteViewModel
    {
        public int Id { get; set; }
        public int IdDiaSemana { get; set; }
        public Guid IdHemocentro { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public DiaSemanaViewModel DiaSemana { get; set; }
    }
}
