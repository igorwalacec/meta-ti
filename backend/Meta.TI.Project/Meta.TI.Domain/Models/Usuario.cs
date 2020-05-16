using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public bool Ativo { get; set; }
        public int? IdTipoSanguineo { get; set; }
        public int IdEndereco { get; set; }
        public int IdTipoLogin { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public TipoSanguineo TipoSanguineo { get; set; }
        public Endereco Endereco { get; set; }
        public  TipoLogin TipoLogin { get; set; }
    }
}
