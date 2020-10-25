using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class Agendamento
    {
        public Agendamento()
        {
        }

        public Agendamento(Usuario usuario, Hemocentro hemocentro, DateTime dataAgendamento)
        {
            Usuario = usuario;
            Hemocentro = hemocentro;
            DataAgendamento = dataAgendamento;
        }

        public Agendamento(Guid id, Usuario usuario, Hemocentro hemocentro, DateTime dataAgendamento)
        {
            Id = id;
            Usuario = usuario;
            Hemocentro = hemocentro;
            DataAgendamento = dataAgendamento;
        }

        public Agendamento(Guid id, Guid idUsuario, Guid idHemocentro, DateTime dataAgendamento)
        {
            Id = id;
            IdUsuario = idUsuario;
            IdHemocentro = idHemocentro;
            DataAgendamento = dataAgendamento;
        }

        [Key]
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdHemocentro { get; set; }
        public DateTime DataAgendamento { get; set; }

        public Usuario Usuario { get; set; }
        public Hemocentro Hemocentro { get; set; }

        public void GerarId()
        {
            Id = Guid.NewGuid();
        }
    }
}
