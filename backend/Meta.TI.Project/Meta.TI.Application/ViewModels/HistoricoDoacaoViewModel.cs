using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Models;

namespace Meta.TI.Application.ViewModels
{
    public class HistoricoDoacaoViewModel
    {
        public Guid IdUsuario { get; set; }
        public DateTime DataCadastro { get; set; }
        public Guid IdHemocentro { get; set; }

        public Hemocentro Hemocentro { get; set; }
    }
}
