using System;
using System.Collections.Generic;

namespace RoboNotificacoesFirebase.Model.Entidades
{
    public partial class Campanha
    {
        public int Id { get; set; }
        public Guid IdHemocentro { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public virtual Hemocentro IdHemocentroNavigation { get; set; }
    }
}
