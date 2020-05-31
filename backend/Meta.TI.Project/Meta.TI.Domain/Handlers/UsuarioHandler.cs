using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Notifications;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Commands.Contracts;
using Meta.TI.Domain.Handlers.Contracts;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;

namespace Meta.TI.Domain.Handlers
{
    public class UsuarioHandler : Notifiable,
                            IHandler<CriacaoUsuarioCommand>
    {
        private readonly IEnderecoRepository enderecoRepository;
        private readonly IUsuarioRepository usuarioRepository;
        public UsuarioHandler(IEnderecoRepository _enderecoRepository, IUsuarioRepository _usuarioRepository)
        {
            enderecoRepository = _enderecoRepository;
            usuarioRepository = _usuarioRepository;
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
                command.IdTipoSanguineo,
                endereco
            );

            enderecoRepository.Adicionar(endereco);

            usuario.SetarIdEndereco(endereco.Id);
            usuario.GerarId();
            usuario.SetarUsuarioAtivo();
            usuario.SetarDataCriacao(DateTime.Now);

            usuarioRepository.Adicionar(usuario);
            //TODO: Validar se CPF já esta cadastrado
            //TODO: Validar se e-mail já esta cadastrado

            var novoUsuario = new Usuario(
                usuario.Id,
                command.Nome,
                command.Sobrenome,
                command.Email,
                command.RG,
                command.CPF,
                command.DataNascimento,
                command.IdTipoSanguineo,
                endereco
            );

            return new GenericCommandResult(true, "Usuário cadastrado!", novoUsuario);
        }
    }
}
