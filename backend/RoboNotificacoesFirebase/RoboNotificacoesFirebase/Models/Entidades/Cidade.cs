using System.Collections.Generic;

namespace RoboNotificacoesFirebase.Model.Entidades
{
    public partial class Cidade
    {
        public Cidade()
        {
            Endereco = new HashSet<Endereco>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdEstado { get; set; }

        public virtual ICollection<Endereco> Endereco { get; set; }
    }
}
