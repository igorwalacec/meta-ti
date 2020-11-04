using System;
using System.ComponentModel.DataAnnotations;

namespace Meta.TI.Domain.Models
{
    public class Notificacoes
    {
        public Notificacoes()
        {
        }

        public Notificacoes(string titulo, string descricao, Usuario usuario)
        {
            Titulo = titulo;
            Descricao = descricao;
            Usuario = usuario;
        }

        public Notificacoes(Guid id, string titulo, string descricao, Usuario usuario)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Usuario = usuario;
        }

        [Key]
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public Usuario Usuario { get; set; }

        public void SetarDataCriacao(DateTime data)
        {
            DataCriacao = data;
        }
    }
}
