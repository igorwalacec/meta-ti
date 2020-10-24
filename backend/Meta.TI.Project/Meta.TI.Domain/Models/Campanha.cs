using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class Campanha 
    {
        public Campanha()
        {
        }

        public Campanha(string titulo, string descricao, Hemocentro hemocentro)
        {
            Titulo = titulo;
            Descricao = descricao;
            Hemocentro = hemocentro;
        }

        public Campanha(int id, string titulo, string descricao, Hemocentro hemocentro)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Hemocentro = hemocentro;
        }

        public Campanha(int id, string titulo, string descricao, DateTime dateCriacao, Guid idHemocentro)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            DataCriacao = dateCriacao;
            IdHemocentro = idHemocentro;
        }

        [Key]
        public int Id { get; set; }
        public Guid IdHemocentro { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public Hemocentro Hemocentro { get; set; }

        public void SetarDataCriacao(DateTime data)
        {
            DataCriacao = data;
        }
        public void SetarDataAlteracao(DateTime data)
        {
            DataAlteracao = data;
        }
        public void AlterarCampanha(string titulo, string descricao)
        {
            Titulo = titulo;
            Descricao = descricao;
        }
    }
}
