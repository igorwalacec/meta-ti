using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class HistoricoAptidao
    {
        public int Id { get; set; }
        public int Usuario_Id { get; set; }
        public int ResultadoAptidao_Id { get; set; }

        public ResultadoAptidao ResultadoAptidao { get; set; }
        public Usuario Usuario { get; set; }
    }
}
