using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class TipoSanguineo
    {
        public TipoSanguineo()
        {

        }
        public TipoSanguineo(int id)
        {
            Id = id;
        }
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
        public ICollection<EstoqueSanguineo> EstoquesSanguineos { get; set; }
    }
}
