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
        public ICollection<RespostasAptidao> RespostasAptidao { get; set; }

        public class CalculoDto
        {
            public DateTime DataProximaDoacao { get; set; }
            public int NumeroDiasAfastado { get; set; }
        }

        public CalculoDto CalcularData()
        {
            var dataAtual = DateTime.Now;
            var numeroDiasAfastado = 0;

            if (this.NumeroDiasAfastado == -1 && this.ImpeditivoDefinitivo) numeroDiasAfastado = 36500;

            else if (this.NumeroDiasAfastado == -1 && this.ImpeditivoDeterminado &&
                (this.Id == 1 || this.Id == 2 || this.Id == 3)) numeroDiasAfastado = 0;

            else if (this.NumeroDiasAfastado == -1 && this.ImpeditivoDeterminado &&
                (this.Id == 5 || this.Id == 8 || this.Id == 17 || this.Id == 18)) numeroDiasAfastado = 90;

            else
                numeroDiasAfastado = this.NumeroDiasAfastado;

            var dto = new CalculoDto
            {
                DataProximaDoacao = dataAtual.AddDays(numeroDiasAfastado),
                NumeroDiasAfastado = numeroDiasAfastado
            };

            return dto;
        }
    }
}
