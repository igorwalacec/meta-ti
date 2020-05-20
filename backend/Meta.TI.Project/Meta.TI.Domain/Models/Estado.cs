using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class Estado
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }  
        public string UF { get; set; }
        public ICollection<Cidade> Cidades { get; set; }
    }
}
