using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Complemento{ get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int IdCidade { get; set; }

        public Cidade Cidade { get; set; }
        public Usuario Usuario { get; set; }
        public Hemocentro Hemocentro { get; set; }

    }
}
