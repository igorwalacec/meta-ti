using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Application.ViewModels
{
    public class CampanhaViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public HemocentroViewModel Hemocentro { get; set; }
    }
}
