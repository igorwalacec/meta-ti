using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class FeedSolicitacao
    {
        public FeedSolicitacao()
        {
        }

        public FeedSolicitacao(string descricao, Usuario usuario, Hemocentro hemocentro, TipoSanguineo tipoSanguineo)
        {
            Descricao = descricao;
            Usuario = usuario;
            Hemocentro = hemocentro;
            TipoSanguineo = tipoSanguineo;
        }

        public FeedSolicitacao(int id, string descricao, Usuario usuario, Hemocentro hemocentro, TipoSanguineo tipoSanguineo)
        {
            Id = id;
            Descricao = descricao;
            Usuario = usuario;
            Hemocentro = hemocentro;
            TipoSanguineo = tipoSanguineo;
        }

        [Key]
        public int Id { get; set; }
        public Guid IdHemocentro { get; set; }
        public Guid IdUsuario { get; set; }
        public int IdTipoSanguineo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public Usuario Usuario { get; set; }
        public Hemocentro Hemocentro { get; set; }
        public TipoSanguineo TipoSanguineo { get; set; }

        public void SetarDataCriacao(DateTime data)
        {
            DataCriacao = data;
        }
        public void SetarDataAlteracao(DateTime data)
        {
            DataAlteracao = data;
        }
        public void AlterarFeedSolicitacao(string descricao, int idTipoSanguineo, Guid idHemocentro)
        {
            Descricao = descricao;
            IdTipoSanguineo = idTipoSanguineo;
            IdHemocentro = idHemocentro;
        }
    }
}
