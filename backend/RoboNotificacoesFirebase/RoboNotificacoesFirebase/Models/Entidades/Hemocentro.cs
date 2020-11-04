using System;
using System.Collections.Generic;

namespace RoboNotificacoesFirebase.Model.Entidades
{
    public partial class Hemocentro
    {
        public Hemocentro()
        {
            Campanha = new HashSet<Campanha>();
            EstoqueSanguineo = new HashSet<EstoqueSanguineo>();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public bool Aprovado { get; set; }
        public bool Ativo { get; set; }
        public int IdEndereco { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public virtual ICollection<Campanha> Campanha { get; set; }
        public virtual ICollection<EstoqueSanguineo> EstoqueSanguineo { get; set; }
    }
}
