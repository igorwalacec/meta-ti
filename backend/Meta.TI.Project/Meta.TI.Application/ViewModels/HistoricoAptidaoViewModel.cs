using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Models;

namespace Meta.TI.Application.ViewModels
{
    public class HistoricoAptidaoViewModel
    {
        public int Id { get; set; }
        public Guid Usuario_Id { get; set; }
        public int ResultadoAptidao_Id { get; set; }
        public ResultadoAptidao ResultadoAptidao { get; set; }        
    }
}
