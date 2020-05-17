using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class Funcionario
    {
        [Key]
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string CPF { get; set; }
        public bool Ativo { get; set; }
        public Guid? IdHemocentro { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public Hemocentro Hemocentro { get; set; }
    }
}
