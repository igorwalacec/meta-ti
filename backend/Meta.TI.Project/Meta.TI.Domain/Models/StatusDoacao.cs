using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class StatusDoacao
    {
        [Key]
        public int Id { get; set; }
        public int IdStatus { get; set; }
        public string Descricao { get; set; }

        public ICollection<ResultadoAptidao> ResultadoAptidao { get; set; }
    }
}
