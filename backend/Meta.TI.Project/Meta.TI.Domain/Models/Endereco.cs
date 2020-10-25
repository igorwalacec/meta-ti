using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class Endereco
    {
        public Endereco()
        {

        }
        public Endereco(string logradouro, string complemento, string numero, string cep, int idCidade)
        {
            Logradouro = logradouro;
            Complemento = complemento;
            Numero = numero;
            Cep = cep;
            IdCidade = idCidade;
        }

        public Endereco(int id, string logradouro, string complemento, string numero, string cep, int idCidade)
        {
            Id = id;
            Logradouro = logradouro;
            Complemento = complemento;
            Numero = numero;
            Cep = cep;
            IdCidade = idCidade;
        }

        [Key]
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Complemento{ get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int IdCidade { get; set; }

        public Cidade Cidade { get; set; }
        public Usuario Usuario { get; set; }
        public Hemocentro Hemocentro { get; set; }

    }
}
