using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class HistoricoAptidao
    {
        [Key]
        public int Id { get; set; }
        public Guid Usuario_Id { get; set; }
        public int ResultadoAptidao_Id { get; set; }

        public ResultadoAptidao ResultadoAptidao { get; set; }
        public Usuario Usuario { get; set; }
    }
}
