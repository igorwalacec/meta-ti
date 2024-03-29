using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class RespostasAptidao
    {
        public RespostasAptidao()
        {

        }

        public RespostasAptidao(int questoesAptidaoId, int resultadoAptidaoId, bool resposta)
        {
            QuestoesAptidao_Id = questoesAptidaoId;
            ResultadoAptidao_Id = resultadoAptidaoId;
            Resposta = resposta;
        }

        [Key]
        public int Id { get; set; }
        public int QuestoesAptidao_Id { get; set; }
        public int ResultadoAptidao_Id { get; set; }
        public bool Resposta { get; set; }

        public QuestoesAptidao QuestoesAptidao { get; set; }
        public ResultadoAptidao ResultadoAptidao { get; set; }
    }
}
