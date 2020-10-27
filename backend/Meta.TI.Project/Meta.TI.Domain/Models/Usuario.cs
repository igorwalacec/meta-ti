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
            DateTime dataNascimento, int idTipoSexo, int? idTipoSanguineo, Endereco endereco)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            Senha = CriptografarSenha(senha);
            this.RG = RG;
            this.CPF = CPF;
            DataNascimento = dataNascimento;
            IdTipoSexo = idTipoSexo;
            IdTipoSanguineo = idTipoSanguineo == 0 ? null : IdTipoSanguineo;
            Endereco = endereco;
        }
        public Usuario(
            Guid id, string nome, string sobrenome,
            string email, string senha, string RG, string CPF,
            DateTime dataNascimento, int idTipoSexo, int? idTipoSanguineo, Endereco endereco)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            Senha = senha;
            this.RG = RG;
            this.CPF = CPF;
            DataNascimento = dataNascimento;
            IdTipoSexo = idTipoSexo;
            IdTipoSanguineo = idTipoSanguineo == 0 ? null : idTipoSanguineo;
            IdEndereco = endereco.Id;
            Endereco = endereco;
            if (IdTipoSanguineo != null)
            {
                TipoSanguineo = new TipoSanguineo((int)idTipoSanguineo);
            }
        }

        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
        public int IdTipoSexo { get; set; }
        public int? IdTipoSanguineo { get; set; }
        public int IdEndereco { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public TipoSanguineo TipoSanguineo { get; set; }
        public TipoSexo TipoSexo { get; set; }
        public Endereco Endereco { get; set; }
        public ICollection<FeedSolicitacao> FeedSolicitacoes { get; set; }
        public ICollection<Agendamento> Agendamentos { get; set; }                
        public ICollection<HistoricoAptidao> HistoricoAptidao { get; set; }

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
        public void AlterarTipoSanguineo(int idTipoSanguineo)
        {
            this.IdTipoSanguineo = idTipoSanguineo;
        }
    }
}
