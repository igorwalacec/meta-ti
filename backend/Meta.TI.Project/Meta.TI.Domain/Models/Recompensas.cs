using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class Recompensas
    {
        public Recompensas()
        {

        }

        public Recompensas(string descricao, int idPatrocinador)
        {
            Descricao = descricao;
            IdPatrocinador = idPatrocinador;
            Ativo = true;
        }
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int IdPatrocinador { get; set; }
        public bool Ativo { get; set; }

        public Level Level { get; set; }
        public Patrocinador Patrocinador { get; set; }

        public void AlterarAtivo(bool novoAtivo)
        {
            this.Ativo = novoAtivo;
        }
    }
}
