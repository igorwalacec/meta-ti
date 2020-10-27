using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Domain.Dto
{
    public class EstoqueSanguineoDto
    {
        public int IdTipoSanguineo { get; set; }
        public Guid IdHemocentro { get; set; }
        public int QuantidadeBolsas { get; set; }
        public int QuantidadeMinimaBolsas { get; set; }
    }
}
