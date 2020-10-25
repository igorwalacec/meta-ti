using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Flunt.Notifications;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Commands.Contracts;
using Meta.TI.Domain.Extensions;
using Meta.TI.Domain.Handlers.Contracts;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Meta.TI.Domain.Handlers
{
    public class FuncionarioHandler : Notifiable,
                                IHandler<CriacaoFuncionarioCommand>,
                                IHandler<TokenCommand>
    {
        private readonly string secret;
        private readonly string expirationDate;
        private readonly IConfiguration configuration;
        //private readonly IEnderecoRepository enderecoRepository;
        private readonly IFuncionarioRepository funcionarioRepository;
        public FuncionarioHandler(IConfiguration _configuration,
                                  //IEnderecoRepository _enderecoRepository,
                                  IFuncionarioRepository _funcionarioRepository)
        {
            configuration = _configuration;

            secret = configuration.GetSection("JwtConfig")
                .GetSection("secret").Value;

            expirationDate = configuration.GetSection("JwtConfig")
                .GetSection("expirationInMinutes").Value;

            //enderecoRepository = _enderecoRepository;

            funcionarioRepository = _funcionarioRepository;
        }
        public ICommandResult Handle(CriacaoFuncionarioCommand command)
        {
            command.Validate();
            if(command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }

            if (funcionarioRepository.VerificarExistenciaCPF(command.CPF))
            {
                command.AddNotification(new Notification("CPF", "CPF já cadastrado!"));
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }
            if(funcionarioRepository.VerificarExistenciaEmail(command.Email))
            {
                command.AddNotification(new Notification("E-mail", "E-mail já cadastrado!"));
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }

            var funcionario = new Funcionario(
                command.NomeCompleto,
                command.Email,
                command.Senha,
                command.CPF,
                command.IdHemocentro
                
            );

            funcionario.GerarId();
            funcionario.SetarFuncionarioAtivo();
            funcionario.SetarDataCriacao(DateTime.Now);

            funcionarioRepository.Adicionar(funcionario);

            var novoFuncionario = new Funcionario(
                funcionario.Id,
                command.NomeCompleto,
                command.Email,
                command.CPF
            );

            return new GenericCommandResult(true, "Funcionário cadastrado!", novoFuncionario);
        }

        public ICommandResult Handle(TokenCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, parece que suas informações estão inválidas.", command.Notifications);
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);


            var funcionario = funcionarioRepository.ObterFuncionarioPorEmailSenha(command.Email, command.Senha.GetMd5Hash());
            if (funcionario != null)
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]{
                    new Claim(ClaimTypes.Email, funcionario.Email),
                    new Claim(ClaimTypes.PrimarySid, funcionario.Id.ToString()),
                    new Claim(ClaimTypes.PrimaryGroupSid, funcionario.IdHemocentro.ToString()),
                    new Claim(ClaimTypes.Name, funcionario.NomeCompleto),
                    new Claim(ClaimTypes.Role, "funcionario")
                }),
                    Expires = DateTime.UtcNow.AddMinutes(double.Parse(expirationDate)),
                    SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                var funcionarioToken = new
                {
                    funcionario = new
                    {
                        funcionario.Id,
                        funcionario.NomeCompleto,
                        funcionario.Email,
                        funcionario.IdHemocentro
                    },
                    token = tokenHandler.WriteToken(token)
                };

                return new GenericCommandResult(true, "token gerado com sucesso", funcionarioToken);
            }
            else
            {
                return new GenericCommandResult(false, "funcionário não encontrado");
            }
        }
    }
}
