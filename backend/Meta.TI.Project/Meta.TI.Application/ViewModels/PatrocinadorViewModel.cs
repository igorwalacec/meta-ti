using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Models;

namespace Meta.TI.Application.ViewModels
{
    public class PatrocinadorViewModel
    {
        public int Id { get; set; }
        public string NomePatrocinador { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Recompensas> Recompensas { get; set; }
    }
}
