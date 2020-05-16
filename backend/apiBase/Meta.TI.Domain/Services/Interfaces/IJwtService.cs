using Meta.TI.Domain.Entities;

namespace Meta.TI.Domain.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateSecurityToken(string email, string password);
    }
}