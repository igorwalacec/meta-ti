using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Domain.Dto
{
    public class RetornoDayOffDto
    {
        public int DiasAfastados { get; set; }
        public DateTime DataProximaDoacao { get; set; }
        public string StatusDoacao { get; set; }
    }
}
