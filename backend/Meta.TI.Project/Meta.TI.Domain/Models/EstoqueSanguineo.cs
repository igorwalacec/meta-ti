using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class EstoqueSanguineo
    {
        public EstoqueSanguineo()
        {
        }

        public EstoqueSanguineo(int quantidadeBolsas,
            int quantidadeMinimaBolsas, TipoSanguineo tipoSanguineo, Hemocentro hemocentro)
        {
            QuantidadeBolsas = quantidadeBolsas;
            QuantidadeMinimaBolsas = quantidadeMinimaBolsas;
            TipoSanguineo = tipoSanguineo;
            Hemocentro = hemocentro;
        }

        public EstoqueSanguineo(int id, int quantidadeBolsas,
            int quantidadeMinimaBolsas, TipoSanguineo tipoSanguineo, Hemocentro hemocentro)
        {
            Id = id;
            QuantidadeBolsas = quantidadeBolsas;
            QuantidadeMinimaBolsas = quantidadeMinimaBolsas;
            TipoSanguineo = tipoSanguineo;
            Hemocentro = hemocentro;
        }

        [Key]
        public int Id { get; set; }
        public int IdTipoSanguineo { get; set; }
        public Guid IdHemocentro { get; set; }
        public int QuantidadeBolsas { get; set; }
        public int QuantidadeMinimaBolsas { get; set; }
        public TipoSanguineo TipoSanguineo { get; set; }
        public Hemocentro Hemocentro { get; set; }

    }
}
