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
            CreateMap<TelefoneViewModel, Telefone>()
                .ConstructUsing(c => new Telefone());
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
