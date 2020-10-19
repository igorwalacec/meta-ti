using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Models;

namespace Meta.TI.Domain.Interfaces
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        bool VerificarExistenciaCPF(string cpf);
        bool VerificarExistenciaEmail(string email);
        Funcionario ObterFuncionarioPorEmailSenha(string email, string senha);
    }
}
