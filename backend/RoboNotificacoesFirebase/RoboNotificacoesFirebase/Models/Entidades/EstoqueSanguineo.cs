using System;

namespace RoboNotificacoesFirebase.Model.Entidades
{
    public partial class EstoqueSanguineo
    {
        public int Id { get; set; }
        public int IdTipoSanguineo { get; set; }
        public Guid IdHemocentro { get; set; }
        public int QtdBolsas { get; set; }
        public int QtdMinimaBolsas { get; set; }

        public virtual Hemocentro IdHemocentroNavigation { get; set; }
    }
}
