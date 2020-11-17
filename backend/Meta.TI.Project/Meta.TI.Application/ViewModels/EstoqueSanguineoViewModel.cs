using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Application.ViewModels
{
    public class EstoqueSanguineoViewModel
    {
        public int Id { get; set; }
        public int IdTipoSanguineo { get; set; }        
        public int QuantidadeBolsas { get; set; }
        public int QuantidadeMinimaBolsas { get; set; }
        public TipoSanguineoViewModel TipoSanguineo { get; set; }
    }
}
