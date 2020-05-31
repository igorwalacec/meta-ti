using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Models;

namespace Meta.TI.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        bool VerificarExistenciaCPF(string cpf);
        bool VerificarExistenciaEmail(string email);
    }
}
