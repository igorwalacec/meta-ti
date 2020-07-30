using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class Informativo
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
    }
}
