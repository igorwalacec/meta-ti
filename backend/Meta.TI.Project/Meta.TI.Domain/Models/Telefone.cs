using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class Telefone
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public Guid IdHemocentro { get; set; }

        public Hemocentro Hemocentro { get; set; }
    }
}
