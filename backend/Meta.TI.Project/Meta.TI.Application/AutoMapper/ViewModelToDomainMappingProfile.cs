using AutoMapper;
using Meta.TI.Application.ViewModels;
using Meta.TI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<EstadoViewModel, Estado>()
                .ConstructUsing(c => new Estado());
            CreateMap<CidadeViewModel, Cidade>()
                .ConstructUsing(c => new Cidade());
            CreateMap<TipoSanguineoViewModel, TipoSanguineo>()
                .ConstructUsing(c => new TipoSanguineo());
            CreateMap<EnderecoViewModel, Endereco>()
                .ConstructUsing(c => new Endereco());
            CreateMap<FuncionarioViewModel, Funcionario>()
                .ConstructUsing(c => new Funcionario());
            CreateMap<UsuarioViewModel, Usuario>()
                .ConstructUsing(c =>
                    new Usuario
                    (
                        c.Nome,
                        c.Sobrenome,
                        c.Email,
                        c.Senha,
                        c.RG,
                        c.CPF,
                        c.DataNascimento,
                        c.IdTipoSexo,
                        c.IdTipoSanguineo,
                        new Endereco
                        {
                            Logradouro = c.Endereco.Logradouro,
                            Complemento = c.Endereco.Complemento,
                            Numero = c.Endereco.Numero,
                            Cep = c.Endereco.Cep,
                            IdCidade = c.Endereco.Cidade.Id
                        }));
            CreateMap<HemocentroViewModel, Hemocentro>()
                .ConstructUsing(c =>
                    new Hemocentro
                    (
                        c.Nome,
                        c.CNPJ,
                        new Endereco
                        {
                            Logradouro = c.Endereco.Logradouro,
                            Complemento = c.Endereco.Complemento,
                            Numero = c.Endereco.Numero,
                            Cep = c.Endereco.Cep,
                            IdCidade = c.Endereco.Cidade.Id
                        }));

            CreateMap<FeedSolicitacaoViewModel, FeedSolicitacao>()
                .ConstructUsing(c =>
                    new FeedSolicitacao
                    (
                        c.Id,
                        c.Descricao,
                        new Usuario
                        {
                            Nome = c.Usuario.Nome,
                            Sobrenome = c.Usuario.Sobrenome,
                            Email = c.Usuario.Email,
                            Senha = c.Usuario.Senha,
                            RG = c.Usuario.RG,
                            CPF = c.Usuario.CPF,
                            DataNascimento = c.Usuario.DataNascimento,
                            IdTipoSanguineo = c.Usuario.IdTipoSanguineo,
                        },
                        new Hemocentro
                        {
                           Nome =  c.Hemocentro.Nome,
                           CNPJ = c.Hemocentro.CNPJ,
                        },
                        new TipoSanguineo
                        {
                            Nome = c.TipoSanguineo.Nome,
                        }));
            CreateMap<CampanhaViewModel, Campanha>()
                .ConstructUsing(c =>
                    new Campanha
                    (
                        c.Id,
                        c.Titulo,
                        c.Descricao,
                        new Hemocentro
                        {
                            Nome = c.Hemocentro.Nome,
                            CNPJ = c.Hemocentro.CNPJ,
                        }));
            CreateMap<AgendamentoViewModel, Agendamento>()
               .ConstructUsing(c =>
                   new Agendamento
                   (
                       c.Id,                       
                       new Usuario
                       {
                           Nome = c.Usuario.Nome,
                           Sobrenome = c.Usuario.Sobrenome,
                           Email = c.Usuario.Email,
                           Senha = c.Usuario.Senha,
                           RG = c.Usuario.RG,
                           CPF = c.Usuario.CPF,
                           DataNascimento = c.Usuario.DataNascimento,
                           IdTipoSanguineo = c.Usuario.IdTipoSanguineo,
                       },
                       new Hemocentro
                       {
                           Nome = c.Hemocentro.Nome,
                           CNPJ = c.Hemocentro.CNPJ,
                       },
                       c.DataAgendamento));
            //CreateMap<EstoqueSanguineoViewModel, EstoqueSanguineo>()
            //    .ConstructUsing(c =>
            //        new EstoqueSanguineo
            //        (                        
            //            c.QuantidadeBolsas,
            //            c.QuantidadeMinimaBolsas,
            //            new TipoSanguineo
            //            {
            //                Id = c.TipoSanguineo.Id,
            //                Nome = c.TipoSanguineo.Nome,
            //            },
            //            new Hemocentro
            //            {
            //                Nome = c.Hemocentro.Nome,
            //                CNPJ = c.Hemocentro.CNPJ,
            //            }));
        }
    }
}
