using System;
using System.Collections.Generic;
using Flunt.Notifications;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Commands.Contracts;
using Meta.TI.Domain.Handlers.Contracts;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;

namespace Meta.TI.Domain.Handlers
{
    public class HemocentroHandler : Notifiable,
                                     IHandler<CriacaoHemocentroCommand>,
                                     IHandler<AlterarAtivoHemocentroCommand>
    {
        private readonly IEnderecoRepository enderecoRepository;
        private readonly IHemocentroRepository hemocentroRepository;
        private readonly ITelefoneRepository telefoneRepository;
        private readonly IEstoqueSanquineoRepository estoqueSanquineoRepository;
        private readonly IExpedienteRepository expedienteRepository;

        public HemocentroHandler(IEnderecoRepository _enderecoRepository,
                                 IHemocentroRepository _hemocentroRepository,
                                 ITelefoneRepository _telefoneRepository,
                                 IEstoqueSanquineoRepository _estoqueSanquineoRepository,
                                 IExpedienteRepository _expedienteRepository)
        {
            enderecoRepository = _enderecoRepository;
            hemocentroRepository = _hemocentroRepository;
            telefoneRepository = _telefoneRepository;
            estoqueSanquineoRepository = _estoqueSanquineoRepository;
            expedienteRepository = _expedienteRepository;
        }

        public ICommandResult Handle(CriacaoHemocentroCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }

            if (hemocentroRepository.VerificarExistenciaCNPJ(command.CNPJ))
            {
                command.AddNotification(new Notification("CNPJ", "CNPJ já cadastrado!"));
            }

            var endereco = new Endereco(
                command.Logradouro,
                command.Complemento,
                command.Numero,
                command.Cep,
                command.IdCidade
            );

            var hemocentro = new Hemocentro(
                command.Nome,
                command.CNPJ,
                endereco
            );

            enderecoRepository.Adicionar(endereco);

            hemocentro.SetarIdEndereco(endereco.Id);
            hemocentro.GerarId();
            hemocentro.SetarDataCriacao(DateTime.Now);

            hemocentroRepository.Adicionar(hemocentro);

            var novoHemocentro = new Hemocentro(
                hemocentro.Id,
                command.Nome,
                command.CNPJ,
                endereco
            );

            return new GenericCommandResult(true, "Hemocentro cadastrado", novoHemocentro);
        }

        public ICommandResult Handle(AlterarAtivoHemocentroCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, parece suas informações estão inválidas.", command.Notifications);
            }


            var hemocentro = hemocentroRepository.ObterPorId(command.IdHemocentro);
            hemocentro.SetarStatusHemocentro(command.Ativo);

            hemocentroRepository.Alterar(hemocentro);


            return new GenericCommandResult(true, "Status do hemocentro alterado com sucesso", hemocentro);
        }

        public ICommandResult Handle(AlterarEnderecoHemocentroCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, parece suas informações estão inválidas.", command.Notifications);
            }

            var hemocentro = hemocentroRepository.ObterPorId(command.IdHemocentro);

            var endereco = new Endereco(
               hemocentro.Endereco.Id,
               command.DadosEndereco.Logradouro,
               command.DadosEndereco.Complemento,
               command.DadosEndereco.Numero,
               command.DadosEndereco.Cep,
               command.DadosEndereco.IdCidade
           );

            enderecoRepository.Alterar(endereco);

            return new GenericCommandResult(true, "Endereço alterado com sucesso", hemocentro);
        }

        public ICommandResult Handle(AlterarTelefoneHemocentroCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, parece suas informações estão inválidas.", command.Notifications);
            }

            foreach (var item in command.DadosTelefone)
            {
                var telefone = telefoneRepository.ObterTelefone(item.Id);
                if (telefone != null)
                    telefoneRepository.Alterar(item);
                else
                    telefoneRepository.Adicionar(item);
            };

            return new GenericCommandResult(true, "Telefones alterados com sucesso");
        }

        public ICommandResult Handle(Guid idHemocentro)
        {
            var estoqueSanguineo = estoqueSanquineoRepository.ObterTodosEstoqueSanguineo(idHemocentro);

            return new GenericCommandResult(true, estoqueSanguineo);
        }

        public ICommandResult Handle(ConsultarEstoqueSanquineoCommand command)
        {
            var estoqueSanguineo = estoqueSanquineoRepository.ObterEstoqueSanquineoPorTipo(command.IdHemocentro, command.IdTipoSanguineo);

            return new GenericCommandResult(true, estoqueSanguineo);
        }

        public ICommandResult Handle(AlterarEstoqueSanguineoCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, parece suas informações estão inválidas.", command.Notifications);
            }

            foreach (var item in command.DadosEstoqueSanguineo)
            {
                var estoqueSanguineo = estoqueSanquineoRepository.ObterEstoqueSanquineoPorTipo(item.IdHemocentro, item.IdTipoSanguineo);
                if (estoqueSanguineo != null)
                    estoqueSanquineoRepository.Alterar(item);
                else
                    estoqueSanquineoRepository.Adicionar(item);
            };

            return new GenericCommandResult(true, "Estoques Sanguineos alterados com sucesso");
        }

        public ICommandResult Handle(AlterarExpedienteHemocentroCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, parece suas informações estão inválidas.", command.Notifications);
            }

            foreach (var item in command.DadosExpediente)
            {
                var expediente = expedienteRepository.ObterExpediente(item.Id);
                if (expediente != null)
                    expedienteRepository.Alterar(item);
                else
                    expedienteRepository.Adicionar(item);
            };

            return new GenericCommandResult(true, "Expedientes alterados com sucesso");
        }
    }
}
