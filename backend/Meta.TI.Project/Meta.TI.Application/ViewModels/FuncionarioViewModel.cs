using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Application.ViewModels
{
    public class FuncionarioViewModel
    {
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string CPF { get; set; }
        public Guid? IdHemocentro { get; set; }

        public HemocentroViewModel Hemocentro { get; set; }
    }
}
