using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flunt.Notifications;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Commands.Contracts;
using Meta.TI.Domain.Handlers.Contracts;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;

namespace Meta.TI.Domain.Handlers
{
    public class AgendamentoHandler : Notifiable,
                                      IHandler<ConsultarAgendamentoPorIdCommand>,
                                      IHandler<ConsultarAgendamentoPorIdUsuarioCommand>,
                                      IHandler<CriacaoAgendamentoCommand>,
                                      IHandler<AlterarAgendamentoCommand>,
                                      IHandler<DeletarAgendamentoCommand>
    {
        private readonly IHemocentroRepository hemocentroRepository;
        public readonly IUsuarioRepository usuarioRepository;
        public readonly IAgendamentoRepository agendamentoRepository;

        public AgendamentoHandler(IHemocentroRepository _hemocentroRepository,
                                  IUsuarioRepository _usuarioRepository,
                                  IAgendamentoRepository _agendamentoRepository)
        {
            hemocentroRepository = _hemocentroRepository;
            usuarioRepository = _usuarioRepository;
            agendamentoRepository = _agendamentoRepository;
        }

        public ICommandResult Handle(ConsultarAgendamentoPorIdCommand command)
        {
            var agendamento = agendamentoRepository.ObterAgendamentoPorId(command.Id);

            if (agendamento == null)
                return new GenericCommandResult(false, "Agendamento não encontrado!");

            return new GenericCommandResult(true, agendamento);
        }

        public ICommandResult Handle(ConsultarAgendamentoPorIdUsuarioCommand command)
        {
            var agendamento = agendamentoRepository.ObterAgendamentoPorUsuario(command.IdUsuario);

            if (agendamento.Count() <= 0)
                return new GenericCommandResult(false, "Agendamento não encontrado!");

            return new GenericCommandResult(true, agendamento);
        }

        public ICommandResult Handle(CriacaoAgendamentoCommand command)
        {
            var usuario = usuarioRepository.ObterPorId(command.IdUsuario);
            var hemocentro = hemocentroRepository.ObterPorId(command.IdHemocentro);

            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }
            if (!usuarioRepository.VerificarExistenciaCPF(usuario.CPF))
            {
                command.AddNotification(new Notification("CPF", "Usuário não cadastrado na plataforma!"));
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }
            if (!hemocentroRepository.VerificarExistenciaCNPJ(hemocentro.CNPJ))
            {
                command.AddNotification(new Notification("CNPJ", "Hemocentro não cadastrado na plataforma!"));
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }
            if (agendamentoRepository.VerificarAgendamentoPorUsuario(usuario))
            {
                command.AddNotification(new Notification("Usuario", "Usuario já possui agendamento!"));
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }
            if(command.DataAgendamento < DateTime.Now)
            {
                command.AddNotification(new Notification("DataAgendamento", "Data do agendamento já passou!"));
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }

            var agendamento = new Agendamento(
                usuario,
                hemocentro,
                command.DataAgendamento
            );

            agendamento.GerarId();
            agendamentoRepository.Adicionar(agendamento);
            var novoAgendamento = agendamentoRepository.ObterAgendamentoPorId(agendamento.Id);

            return new GenericCommandResult(true, "Agendamento Cadastrado!", novoAgendamento);
        }

        public ICommandResult Handle(AlterarAgendamentoCommand command)
        {
            var usuario = usuarioRepository.ObterPorId(command.IdUsuario);
            var hemocentro = hemocentroRepository.ObterPorId(command.IdHemocentro);

            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }
            if (!usuarioRepository.VerificarExistenciaCPF(usuario.CPF))
            {
                command.AddNotification(new Notification("CPF", "Usuário não cadastrado na plataforma!"));
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }
            if (!hemocentroRepository.VerificarExistenciaCNPJ(hemocentro.CNPJ))
            {
                command.AddNotification(new Notification("CNPJ", "Hemocentro não cadastrado na plataforma!"));
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }
            if (command.DataAgendamento < DateTime.Now)
            {
                command.AddNotification(new Notification("DataAgendamento", "Data do agendamento já passou!"));
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }

            var agendamento = new Agendamento(
                command.Id,
                command.IdUsuario,
                command.IdHemocentro,
                command.DataAgendamento
            );

            agendamentoRepository.Alterar(agendamento);
            var novoAgendamento = agendamentoRepository.ObterAgendamentoPorId(agendamento.Id);

            return new GenericCommandResult(true, "Agendamento Alterado!", novoAgendamento);
        }

        public ICommandResult Handle(DeletarAgendamentoCommand command)
        {
            agendamentoRepository.Remover(command.Id);

            return new GenericCommandResult(true, "Agendamento removido!");
        }

      
    }
}
