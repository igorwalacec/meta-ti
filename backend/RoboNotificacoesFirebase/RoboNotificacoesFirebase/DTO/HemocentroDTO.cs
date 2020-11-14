using System;
using System.Collections.Generic;
using System.Text;

namespace RoboNotificacoesFirebase.DTO
{
    public class HemocentroDTO
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Cidade { get; set; }
    }
}
