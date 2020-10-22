using System;

namespace Meta.TI.Application.ViewModels
{
    public class AgendamentoViewModel
    {
        public Guid Id { get; set; }
        public DateTime DataAgendamento { get; set; }
        public UsuarioViewModel Usuario { get; set; }
        public HemocentroViewModel Hemocentro { get; set; }
    }
}
