using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class EstoqueSanguineo
    {
        [Key]
        public int Id { get; set; }
        public int IdTipoSanguineo { get; set; }
        public Guid IdHemocentro { get; set; }
        public TipoSanguineo TipoSanguineo { get; set; }
        public Hemocentro Hemocentro { get; set; }
    }
}
