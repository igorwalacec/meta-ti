using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class Expediente
    {
        [Key]
        public int Id { get; set; }
        public int IdDiaSemana { get; set; }
        public Guid IdHemocentro { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public DiaSemana DiaSemana { get; set; }
        public Hemocentro Hemocentro { get; set; }
    }
}
