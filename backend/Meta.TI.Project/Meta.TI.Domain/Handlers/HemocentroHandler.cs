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
                                     IHandler<AlterarExpedienteHemocentroCommand>,
                                     IHandler<ObterExpedientePorIdHemocentroCommand>
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
        public ICommandResult Handle(Guid idHemocentro)
        {
            var hemocentro= hemocentroRepository.ObterHemocentroPorId(idHemocentro);

            return new GenericCommandResult(true, hemocentro);
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
                command.IdCidade,
                command.Latitude,
                command.Longitude
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
            hemocentro.Endereco.Numero = command.DadosEndereco.Numero;
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
                {
                    telefone.Numero = item.Numero;
                    telefoneRepository.Alterar(telefone);
                }
                else
                {
                    Telefone novoTelefone = new Telefone()
                    {
                        Numero = item.Numero,
                        IdHemocentro = item.IdHemocentro
                    };
                    telefoneRepository.Adicionar(novoTelefone);
                }
            };

            return new GenericCommandResult(true, "Telefones alterados com sucesso");
        }

        public ICommandResult Handle(ConsultarTelefoneHemocentroCommand command)
        {
            var telefone = telefoneRepository.ObterTelefonesPorHemocentro(command.IdHemocentro);

            return new GenericCommandResult(true, telefone);
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
               

                if (estoqueSanguineo != null)
                {
                    estoqueSanguineo.QuantidadeBolsas = item.QuantidadeBolsas;
                    estoqueSanguineo.QuantidadeMinimaBolsas = item.QuantidadeMinimaBolsas;

                    estoqueSanquineoRepository.Alterar(estoqueSanguineo);
                }
                else
                {
                    EstoqueSanguineo estoque = new EstoqueSanguineo
                    {
                        IdTipoSanguineo = item.IdTipoSanguineo,
                        IdHemocentro = item.IdHemocentro,
                        QuantidadeBolsas = item.QuantidadeBolsas,
                        QuantidadeMinimaBolsas = item.QuantidadeMinimaBolsas
                    };

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
                var expediente = expedienteRepository.ObterExpediente(item.IdHemocentro, item.IdDiaSemana);

                if (expediente != null)
                {
                    expediente.Inicio = item.Inicio;
                    expediente.Fim = item.Fim;
                    
                    expedienteRepository.Alterar(expediente);
                }
                else
                {
                    var novoExpediente = new Expediente
                    {
                        IdHemocentro = item.IdHemocentro,
                        IdDiaSemana = item.IdDiaSemana,
                        Inicio = item.Inicio,
                        Fim = item.Fim
                    };

                    expedienteRepository.Adicionar(novoExpediente);
                }
            };

            return new GenericCommandResult(true, "Expedientes alterados com sucesso");
        }        

        public ICommandResult Handle(ObterHemocentroPorIdCommand command)
        {
            var hemocentro = hemocentroRepository.ObterHemocentroPorId(command.IdHemocentro);

            return new GenericCommandResult(true, hemocentro);
        }

        public ICommandResult Handle(ObterExpedientePorIdHemocentroCommand command)
        {
            var expedientes = expedienteRepository.ObterExpedientePorIdHemocentro(command.IdHemocentro);

            return new GenericCommandResult(true, expedientes);
        }
    }
}
