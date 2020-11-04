using System;
using System.Collections.Generic;

namespace RoboNotificacoesFirebase.Model.Entidades
{
    public partial class Usuario
    {
        public Usuario()
        {
            Notificacoes = new HashSet<Notificacoes>();
        }

        public Guid Id { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public bool Ativo { get; set; }
        public int? IdTipoSanguineo { get; set; }
        public int IdEndereco { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Nome { get; set; }
        public int IdTipoSexo { get; set; }

        public virtual ICollection<Notificacoes> Notificacoes { get; set; }
    }
}
