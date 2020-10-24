using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Models;

namespace Meta.TI.Application.ViewModels
{
    public class LevelViewModel
    {
        public int Id { get; set; }
        public int Nivel { get; set; }
        public int QuantidadeDoacao { get; set; }
        public int IdRecompensa { get; set; }
        public bool Ativo { get; set; }

        public Recompensas Recompensa { get; set; }
    }
}
