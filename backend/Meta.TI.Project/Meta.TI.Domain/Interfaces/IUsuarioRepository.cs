using Meta.TI.Domain.Models;

namespace Meta.TI.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        bool VerificarExistenciaCPF(string cpf);
        bool VerificarExistenciaEmail(string email);
        Usuario ObterUsuarioPorEmailSenha(string email, string senha);
        Usuario ObterUsuarioPorCPF(string cpf);
    }
}
