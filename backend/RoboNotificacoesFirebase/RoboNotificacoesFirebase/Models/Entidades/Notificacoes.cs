using System;

namespace RoboNotificacoesFirebase.Model.Entidades
{
    public partial class Notificacoes
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public Guid IdHemocentro { get; set; }

        public virtual Hemocentro IdHemocentroNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
