using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Application.ViewModels
{
    public class HemocentroViewModel
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public bool Aprovado { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public EnderecoViewModel Endereco { get; set; }
    }
}
