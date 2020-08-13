using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class QuestoesAptidao
    {
        public int Id { get; set; }
        public string Pergunta { get; set; }
        public int NumeroDiasAfastado { get; set; }
        public bool ImpeditivoDefinitivo { get; set; }
        public bool ImpeditivoDeterminado { get; set; }
        public int? IdTipoSexo { get; set; }
        public TipoSexo TipoSexo { get; set; }
    }
}
