using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Meta.TI.Domain.Entities;
using Meta.TI.Domain.Repositories;
using Meta.TI.Domain.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Meta.TI.Domain.Services
{
    public class JwtService : IJwtService
    {
        private readonly string _secret;
        private readonly string _expirationDate;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public JwtService(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _secret = configuration.GetSection("JwtConfig")
                .GetSection("secret").Value;

            _expirationDate = configuration.GetSection("JwtConfig")
                .GetSection("expirationInMinutes").Value;
        }
        public string GenerateSecurityToken(string email, string password)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            var user = _userRepository.GetObject(x => x.Email == email && x.Password == password);
            if (user != null)
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]{
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name)
                }),
                    Expires = DateTime.UtcNow.AddMinutes(double.Parse(_expirationDate)),
                    SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }
            else
            {
                return null;
            }
        }

    }
}