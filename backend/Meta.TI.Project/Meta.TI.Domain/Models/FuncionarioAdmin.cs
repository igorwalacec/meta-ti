using Meta.TI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class FuncionarioAdmin
    {
        public int Id { get; set; }
        public Guid IdFuncionario { get; set; }
        public Guid IdHemocentro { get; set; }
        public Funcionario Funcionario { get; set; }
        public Hemocentro Hemocentro { get; set; }
    }
}
