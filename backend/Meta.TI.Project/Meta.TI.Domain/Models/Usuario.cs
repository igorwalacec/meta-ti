using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Meta.TI.Domain.Extensions;

namespace Meta.TI.Domain.Models
{
    public class Usuario
    {
        public Usuario()
        {
        }

        public Usuario(
            string nome, string sobrenome, string email,
            string senha, string RG, string CPF,
            DateTime dataNascimento, int? idTipoSanguineo, Endereco endereco)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            Senha = CriptografarSenha(senha);
            this.RG = RG;
            this.CPF = CPF;
            DataNascimento = dataNascimento;
            IdTipoSanguineo = idTipoSanguineo;
            Endereco = endereco;
        }
        public Usuario(
            Guid id, string nome, string sobrenome,
            string email, string RG, string CPF,
            DateTime dataNascimento, int? idTipoSanguineo, Endereco endereco)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            this.RG = RG;
            this.CPF = CPF;
            DataNascimento = dataNascimento;
            IdTipoSanguineo = idTipoSanguineo;
            IdEndereco = endereco.Id;
            Endereco = endereco;
            if (idTipoSanguineo != null)
            {
                TipoSanguineo = new TipoSanguineo((int)idTipoSanguineo);
            }
        }

        [Key]
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string RG { get; private set; }
        public string CPF { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public bool Ativo { get; private set; }
        public int? IdTipoSanguineo { get; private set; }
        public int IdEndereco { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataAlteracao { get; private set; }

        public TipoSanguineo TipoSanguineo { get; private set; }
        public Endereco Endereco { get; private set; }

        public void SetarIdEndereco(int idEndereco)
        {
            IdEndereco = idEndereco;
        }
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
        public void SetarUsuarioAtivo()
        {
            Ativo = true;
        }
    }
}
