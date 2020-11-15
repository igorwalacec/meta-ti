using System;
using System.ComponentModel.DataAnnotations;

namespace Meta.TI.Domain.Models
{
    public class Notificacoes
    {
        public Notificacoes()
        {
        }

        public Notificacoes(string titulo, string descricao, Usuario usuario, Hemocentro hemocentro)
        {
            Titulo = titulo;
            Descricao = descricao;
            Usuario = usuario;
            Hemocentro = hemocentro;
        }

        public Notificacoes(Guid id, string titulo, string descricao, Usuario usuario, Hemocentro hemocentro)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Usuario = usuario;
            Hemocentro = hemocentro;
        }

        [Key]
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdHemocentro { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public Usuario Usuario { get; set; }
        public Hemocentro Hemocentro { get; set; }

        public void SetarDataCriacao(DateTime data)
        {
            DataCriacao = data;
        }
        public void GerarId()
        {
            Id = Guid.NewGuid();
        }
    }
}
