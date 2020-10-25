using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;
using Meta.TI.Infra.Data.Context;

namespace Meta.TI.Infra.Data.Repository
{
    public class FuncionarioRepository: Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(MetaTiContext context) : base(context)
        {
        }

        public bool VerificarExistenciaEmail(string email)
        {
            return DbSet.Where(x => x.Email.ToUpper() == email.ToUpper()).Any();
        }

        public bool VerificarExistenciaCPF(string cpf)
        {
            return DbSet.Where(x => x.CPF.ToUpper() == cpf.ToUpper()).Any();
        }

        public Funcionario ObterFuncionarioPorEmailSenha(string email, string senha)
        {
            return DbSet.FirstOrDefault(x => x.Email == email && x.Senha == senha);
        }
    }
}
