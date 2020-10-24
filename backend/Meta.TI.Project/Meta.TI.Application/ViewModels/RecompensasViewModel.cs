using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Models;

namespace Meta.TI.Application.ViewModels
{
    public class RecompensasViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int IdPatrocinador { get; set; }
        public bool Ativo { get; set; }

        public Level Level { get; set; }
        public Patrocinador Patrocinador { get; set; }
    }
}
