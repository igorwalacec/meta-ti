using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class Cidade
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdEstado{ get; set; }
        public Estado Estado { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }
    }
}
