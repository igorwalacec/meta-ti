using System;
using System.Collections.Generic;

namespace RoboNotificacoesFirebase.Model.Entidades
{
    public partial class StatusDoacao
    {
        public int Id { get; set; }
        public int IdStatus { get; set; }
        public string Descricao { get; set; }
    }
}
