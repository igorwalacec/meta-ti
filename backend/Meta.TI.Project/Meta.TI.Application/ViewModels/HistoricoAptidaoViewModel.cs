using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Models;

namespace Meta.TI.Application.ViewModels
{
    public class HistoricoAptidaoViewModel
    {
        public int DiasAfastados { get; set; }
        public DateTime DataProximaDoacao { get; set; }
        public int StatusDoacao { get; set; }
    }
}
