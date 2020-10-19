using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class Hemocentro
    {
        public Hemocentro()
        {

        }
        public Hemocentro(
            string nome, string CNPJ, Endereco endereco)
        {
            Nome = nome;
            this.CNPJ = CNPJ;
            Endereco = endereco;
        }

        public Hemocentro(
           Guid id, string nome, string CNPJ, Endereco endereco)
        {
            Id = id;
            Nome = nome;
            this.CNPJ = CNPJ;
            Endereco = endereco;          
        }

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
        public ICollection<Funcionario> Funcionarios { get; set; }
        public ICollection<FuncionarioAdmin> FuncionariosAdmin { get; set; }

        public void SetarIdEndereco(int idEndereco)
        {
            IdEndereco = idEndereco;
        }
        public void GerarId()
        {
            Id = Guid.NewGuid();
        }
        public void SetarDataCriacao(DateTime data)
        {
            DataCriacao = data;
        }
        public void SetarDataAlteracao(DateTime data)
        {
            DataAlteracao = data;
        }
        public void SetarStatusHemocentro(bool ativo)
        {
            this.Ativo = ativo;
        }
        public void AlterarEndereco(Endereco endereco)
        {
            this.Endereco = endereco;
        }
    }
}
