using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class Hemocentro
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public bool Aprovado { get; set; }
        public bool Ativo { get; set; }
        public int IdEndereco { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public Endereco Endereco { get; set; }
        public ICollection<EstoqueSanguineo> EstoquesSanguineos { get; set; }
        public ICollection<Expediente> Expedientes { get; set; }
        public ICollection<Telefone> Telefones { get; set; }
    }
}
