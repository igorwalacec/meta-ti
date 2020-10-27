using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Flunt.Notifications;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Commands.Contracts;
using Meta.TI.Domain.Dto;
using Meta.TI.Domain.Extensions;
using Meta.TI.Domain.Handlers.Contracts;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Meta.TI.Domain.Handlers
{
    public class UsuarioHandler : Notifiable,
                            IHandler<CriacaoUsuarioCommand>,
                            IHandler<TokenCommand>,
                            IHandler<AlterarTipoSanguineoCommand>
    {
        private readonly string secret;
        private readonly string expirationDate;
        private readonly IConfiguration configuration;
        private readonly IEnderecoRepository enderecoRepository;
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IHistoricoAptidaoRepository historicoAptidaoRepository;
        private readonly IHistoricoDoacaoRepository historicoDoacaoRepository;
        private readonly IStatusDoacaoRepository statusDoacaoRepository;

        public UsuarioHandler(IConfiguration _configuration,
                                IEnderecoRepository _enderecoRepository,
                                IUsuarioRepository _usuarioRepository,
                                IHistoricoAptidaoRepository _historicoAptidaoRepository,
                                IHistoricoDoacaoRepository _historicoDoacaoRepository,
                                IStatusDoacaoRepository _statusDoacaoRepository)
        {
            configuration = _configuration;

            secret = configuration.GetSection("JwtConfig")
                .GetSection("secret").Value;

            expirationDate = configuration.GetSection("JwtConfig")
                .GetSection("expirationInMinutes").Value;

            enderecoRepository = _enderecoRepository;

            usuarioRepository = _usuarioRepository;

            historicoAptidaoRepository = _historicoAptidaoRepository;

            historicoDoacaoRepository = _historicoDoacaoRepository;

            statusDoacaoRepository = _statusDoacaoRepository;
        }
        public ICommandResult Handle(CriacaoUsuarioCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }

            if (usuarioRepository.VerificarExistenciaCPF(command.CPF))
            {
                command.AddNotification(new Notification("CPF", "CPF já cadastrado!"));
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }
            if (usuarioRepository.VerificarExistenciaEmail(command.Email))
            {
                command.AddNotification(new Notification("E-mail", "E-mail já cadastrado!"));
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }

            var endereco = new Endereco(
                command.Logradouro,
                command.Complemento,
                command.Numero,
                command.Cep,
                command.IdCidade
            );

            var usuario = new Usuario(
                command.Nome,
                command.Sobrenome,
                command.Email,
                command.Senha,
                command.RG,
                command.CPF,
                command.DataNascimento,
                command.IdTipoSexo,
                command.IdTipoSanguineo,
                endereco
            );

            enderecoRepository.Adicionar(endereco);

            usuario.SetarIdEndereco(endereco.Id);
            usuario.GerarId();
            usuario.SetarUsuarioAtivo();
            usuario.SetarDataCriacao(DateTime.Now);

            usuarioRepository.Adicionar(usuario);

            var novoUsuario = new Usuario(
                usuario.Id,
                command.Nome,
                command.Sobrenome,
                command.Email,
                command.RG,
                command.CPF,
                command.DataNascimento,
                command.IdTipoSexo,
                command.IdTipoSanguineo,
                endereco
            );

            return new GenericCommandResult(true, "Usuário cadastrado!", novoUsuario);
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


            var usuario = usuarioRepository.ObterUsuarioPorEmailSenha(command.Email, command.Senha.GetMd5Hash());
            if (usuario != null)
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]{
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.PrimarySid, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Role, "doador")
                }),
                    Expires = DateTime.UtcNow.AddMinutes(double.Parse(expirationDate)),
                    SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                var usuarioToken = new
                {
                    usuario = new
                    {
                        usuario.Id,
                        usuario.Nome,
                        usuario.Email
                    },
                    token = tokenHandler.WriteToken(token)
                };

                return new GenericCommandResult(true, "token gerado com sucesso", usuarioToken);
            }
            else
            {
                return new GenericCommandResult(false, "Usuário não encontrado", null);
            }
        }

        public ICommandResult Handle(AlterarTipoSanguineoCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, parece suas informações estão inválidas.", command.Notifications);
            }

            var usuario = usuarioRepository.ObterPorId(command.IdUsuario);
            usuario.AlterarTipoSanguineo(command.IdTipoSanguineo);

            usuarioRepository.Alterar(usuario);


            return new GenericCommandResult(true, "Tipo sanguíneo alterado com sucesso", usuario);
        }

        public ICommandResult Handle(StatusDoacaoCommand usuarioId)
        {
            var dataAtual = DateTime.Now;
            var retornoDados = historicoAptidaoRepository.CalcularDayOff(usuarioId.IdUsuario);

            if (retornoDados == null) return new GenericCommandResult(false, "Historico de doação não encontrado!", null);

            TimeSpan ts = retornoDados.ResultadoAptidao.DataProximaDoacao.Subtract(dataAtual);
            retornoDados.ResultadoAptidao.DiasAfastados = (int)ts.TotalDays;

            if (retornoDados.ResultadoAptidao.DiasAfastados > 0)
            {
                retornoDados.ResultadoAptidao.IdStatus = 2;
            }
            else
            {
                retornoDados.ResultadoAptidao.IdStatus = 1;
            }

            var status = statusDoacaoRepository.BuscarStatus(retornoDados.ResultadoAptidao.IdStatus);

            var resultado = new RetornoDayOffDto
            {
                DiasAfastados = retornoDados.ResultadoAptidao.DiasAfastados,
                DataProximaDoacao = retornoDados.ResultadoAptidao.DataProximaDoacao,
                StatusDoacao = status
            };

            return new GenericCommandResult(true, resultado);
        }

        public ICommandResult Handle(CadastrarNovaDoacaoCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, parece suas informações estão inválidas.", command.Notifications);
            }

            var novoHistorico = new HistoricoDoacao
            (
                command.IdUsuario,
                command.DataCadastro,
                command.IdHemocentro
            );

            historicoDoacaoRepository.Adicionar(novoHistorico);

            return new GenericCommandResult(true, "Doação adicionada com sucesso!");
        }

        public ICommandResult Handle(AlterarEnderecoUsuarioCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, parece suas informações estão inválidas.", command.Notifications);
            }

            var usuario = usuarioRepository.ObterPorId(command.IdUsuario);
            
            var endereco = new Endereco(
               usuario.Endereco.Id,
               command.DadosEndereco.Logradouro,
               command.DadosEndereco.Complemento,
               command.DadosEndereco.Numero,
               command.DadosEndereco.Cep,
               command.DadosEndereco.IdCidade
           );

            enderecoRepository.Alterar(endereco);           

            return new GenericCommandResult(true, "Endereço alterado com sucesso", usuario);
        }
    }
}
