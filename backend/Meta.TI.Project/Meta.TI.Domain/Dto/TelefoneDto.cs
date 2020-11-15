using System;

namespace Meta.TI.Domain.Dto
{
    public class TelefoneDto
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public Guid IdHemocentro { get; set; }
    }
}
