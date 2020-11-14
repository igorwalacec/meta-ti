using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Application.ViewModels
{
    public class NotificacoesViewModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public UsuarioViewModel Usuario { get; set; }
        public HemocentroViewModel Hemocentro { get; set; }
    }
}
