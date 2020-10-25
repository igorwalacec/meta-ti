using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Text;
using Meta.TI.Domain.Extensions;

namespace Meta.TI.Domain.Models
{
    public class Funcionario
    {
        public Funcionario()
        {
        }

        public Funcionario(string nomeCompleto, string email, string senha, string cpf, Guid? idHemocentro)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            Senha = CriptografarSenha(senha);
            CPF = cpf;
            IdHemocentro = idHemocentro;
        }
        public Funcionario(Guid id, string nomeCompleto, string email, string cpf)
        {
            Id = id;
            NomeCompleto = nomeCompleto;
            Email = email;
            CPF = cpf;
        }

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
        public FuncionarioAdmin FuncionarioAdmin { get; set; }

        public void GerarId()
        {
            Id = Guid.NewGuid();
        }
        private string CriptografarSenha(string senhaNormal)
        {
            return senhaNormal.GetMd5Hash();
        }
        public void SetarDataCriacao(DateTime data)
        {
            DataCriacao = data;
        }
        public void SetarDataAlteracao(DateTime data)
        {
            DataAlteracao = data;
        }
        public void SetarFuncionarioAtivo()
        {
            Ativo = true;
        }
    }
}
