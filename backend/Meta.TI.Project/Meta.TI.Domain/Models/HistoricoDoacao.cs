using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class HistoricoDoacao
    {
        public HistoricoDoacao()
        {

        }
        public HistoricoDoacao(Guid idUsuario, DateTime dataCadastro, Guid idHemocentro)
        {
            IdUsuario = idUsuario;
            DataCadastro = dataCadastro;
            IdHemocentro = idHemocentro;
        }

        public int Id { get; set; }
        public Guid IdUsuario { get; set; }
        public DateTime DataCadastro { get; set; }
        public Guid IdHemocentro { get; set; }

        public Hemocentro Hemocentro { get; set; }
    }
}
