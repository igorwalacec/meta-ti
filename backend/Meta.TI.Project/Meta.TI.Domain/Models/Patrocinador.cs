using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class Patrocinador
    {
        public Patrocinador()
        {

        }

        public Patrocinador(string nomePatrocinador)
        {
            NomePatrocinador = nomePatrocinador;
            Ativo = true;
        }
        public int Id { get; set; }
        public string NomePatrocinador { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Recompensas> Recompensas { get; set; }

        public void AlterarAtivo(bool novoAtivo)
        {
            this.Ativo = novoAtivo;
        }
    }
}
