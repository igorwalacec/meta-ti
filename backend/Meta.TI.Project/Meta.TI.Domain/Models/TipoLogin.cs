using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class TipoLogin
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool SenhaObrigatoria { get; set; }        
        public Usuario Usuario { get; set; }
    }
}
