using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class Level
    {
        public Level()
        {

        }

        public Level(int nivel, int quantidadeDoacao, int idRecompensa)
        {
            Nivel = nivel;
            QuantidadeDoacao = quantidadeDoacao;
            IdRecompensa = idRecompensa;
            Ativo = true;
        }

        public int Id { get; set; }
        public int Nivel { get; set; }
        public int QuantidadeDoacao { get; set; }
        public int IdRecompensa { get; set; }
        public bool Ativo { get; set; }

        public Recompensas Recompensa { get; set; }

        public void AlterarAtivo(bool novoAtivo)
        {
            this.Ativo = novoAtivo;
        }
    }
}
