using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Br.Extensions;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;

namespace Meta.TI.Domain.Commands
{
    public class CriacaoHemocentroCommand : Notifiable, ICommand
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public bool Aprovado { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public int IdCidade { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNullOrEmpty(Nome, "Nome", "Por favor, digite o nome do Hemocentro.")
                .HasExactLengthIfNotNullOrEmpty(CNPJ, 14, "CNPJ", "CNPJ deve ter 14 digitos obrigatoriamente.")
                .IsNotNullOrEmpty(CNPJ, "CNPJ", "Por favor, informe o CNPJ.")
                .IsCnpj(CNPJ, "CNPJ", "CNPJ inválido.")
                .IsNotNullOrEmpty(Logradouro, "Logradouro", "Por favor, digite o seu logradouro.")
                .IsNotNullOrEmpty(Numero, "Número", "Por favor, digite um número.")
                .IsNotNullOrEmpty(Cep, "CEP", "Por favor, digite seu CEP.")
                .IsNotNull(IdCidade, "Cidade", "Por favor, selecione uma cidade.")
            );
        }
    }
}
