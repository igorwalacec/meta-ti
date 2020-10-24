using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Notifications;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Commands.Contracts;
using Meta.TI.Domain.Handlers.Contracts;
using Meta.TI.Domain.Interfaces;

namespace Meta.TI.Domain.Handlers
{
    public class CompartilhamentoWhatsappHandler : Notifiable,
                                             IHandler<CompartilhamentoWhatsappCommand>
    {
        private readonly IUsuarioRepository usuarioRepository;

        public CompartilhamentoWhatsappHandler(IUsuarioRepository _usuarioRepository)
        {
            usuarioRepository = _usuarioRepository;
        }

        public ICommandResult Handle(CompartilhamentoWhatsappCommand command)
        {
            var usuario = usuarioRepository.ObterUsuarioPorId(command.IdUsuario);

            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, parece seu Envio está inválido.", command.Notifications);
            }
            if (command.NumeroCelular.IsValidNumber())
            {
                command.AddNotification(new Notification("Número", "Número de celular inválido!"));
                return new GenericCommandResult(false, "Ops, parece que o número digitado está inválido.", command.Notifications);
            }
            if (!usuarioRepository.VerificarExistenciaCPF(usuario.CPF))
            {
                command.AddNotification(new Notification("CPF", "Usuário não cadastrado na plataforma!"));
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }

            string mensagem = string.Concat("Olá, seu amigo(a)", usuario.Nome.FirstCharToUpper() ,
                              " te convidou para uma boa ação! Venha conhecer mais nossa plataforma, contamos com você!");
            string urlWhatsapp = string.Concat("whatsapp://send?phone=55", command.NumeroCelular, "Text=", mensagem);

            return new GenericCommandResult(true, "Url para envio do convite!", urlWhatsapp);
        }
    }
}
