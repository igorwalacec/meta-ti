using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Meta.TI.Domain.Models
{
    public class Telefone
    {
        //public Telefone()
        //{
        //}

        //public Telefone(string numero, Guid idHemocentro)
        //{
        //    Numero = numero;
        //    IdHemocentro = idHemocentro;
        //}

        //public Telefone(int id, string numero, Guid idHemocentro)
        //{
        //    Id = id;
        //    Numero = numero;
        //    IdHemocentro = idHemocentro;
        //}

        [Key]
        public int Id { get; set; }
        public string Numero { get; set; }
        public Guid IdHemocentro { get; set; }

        public Hemocentro Hemocentro { get; set; }
    }
}
