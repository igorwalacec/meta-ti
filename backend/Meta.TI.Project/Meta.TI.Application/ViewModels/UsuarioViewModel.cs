using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string NomeCompleto { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public int IdTipoSexo { get; set; }
        public int? IdTipoSanguineo { get; set; }

        public TipoSanguineoViewModel TipoSanguineo { get; set; }
        public EnderecoViewModel Endereco { get; set; }
    }
}
