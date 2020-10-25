using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Application.ViewModels
{
    public class FeedSolicitacaoViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public HemocentroViewModel Hemocentro { get; set; }
        public UsuarioViewModel Usuario { get; set; }
        public TipoSanguineoViewModel TipoSanguineo { get; set; }
    }
}
