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
                                     IHandler<AlterarAtivoHemocentroCommand>,
                                     IHandler<AlterarEnderecoHemocentroCommand>,
                                     IHandler<AlterarTelefoneHemocentroCommand>,
                                     IHandler<ConsultarEstoqueSanguineoPorHemocentroCommand>,
                                     IHandler<ConsultarEstoqueSanquineoCommand>,
                                     IHandler<AlterarEstoqueSanguineoCommand>,
                                     IHandler<AlterarExpedienteHemocentroCommand>
    {
        private readonly IEnderecoRepository enderecoRepository;
        private readonly IHemocentroRepository hemocentroRepository;
        private readonly ITelefoneRepository telefoneRepository;
        private readonly IEstoqueSanguineoRepository estoqueSanquineoRepository;
        private readonly IExpedienteRepository expedienteRepository;

        public HemocentroHandler(IEnderecoRepository _enderecoRepository,
                                 IHemocentroRepository _hemocentroRepository,
                                 ITelefoneRepository _telefoneRepository,
                                 IEstoqueSanguineoRepository _estoqueSanquineoRepository,
                                 IExpedienteRepository _expedienteRepository)
        {
            enderecoRepository = _enderecoRepository;
            hemocentroRepository = _hemocentroRepository;
            telefoneRepository = _telefoneRepository;
            estoqueSanquineoRepository = _estoqueSanquineoRepository;
            expedienteRepository = _expedienteRepository;
        }

        public ICommandResult Handle()
        {
            var todosHemocentro = hemocentroRepository.ObterTodosHemocentro();

            return new GenericCommandResult(true, todosHemocentro);
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

            var hemocentro = hemocentroRepository.ObterHemocentroPorId(command.IdHemocentro);

            hemocentro.Endereco.Logradouro = command.DadosEndereco.Logradouro;
            hemocentro.Endereco.Complemento = command.DadosEndereco.Complemento;
            hemocentro.Endereco.Numero= command.DadosEndereco.Numero;
            hemocentro.Endereco.Cep = command.DadosEndereco.Cep;
            hemocentro.Endereco.IdCidade = command.DadosEndereco.IdCidade;
            hemocentro.Endereco.Latitude = command.DadosEndereco.Latitude;
            hemocentro.Endereco.Longitude = command.DadosEndereco.Longitude;

            enderecoRepository.Alterar(hemocentro.Endereco);

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

        public ICommandResult Handle(ConsultarEstoqueSanguineoPorHemocentroCommand command)
        {
            var estoqueSanguineo = estoqueSanquineoRepository.ObterTodosEstoqueSanguineo(command.IdHemocentro);

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
                EstoqueSanguineo estoque = new EstoqueSanguineo
                {
                    IdTipoSanguineo = item.IdTipoSanguineo,
                    IdHemocentro = item.IdHemocentro,
                    QuantidadeBolsas = item.QuantidadeBolsas,
                    QuantidadeMinimaBolsas = item.QuantidadeMinimaBolsas
                };

                if (estoqueSanguineo != null)
                    estoqueSanquineoRepository.Alterar(estoque);
                else
                {
                    estoque.Id = estoqueSanguineo.Id;
                    estoqueSanquineoRepository.Adicionar(estoque);
                }
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
