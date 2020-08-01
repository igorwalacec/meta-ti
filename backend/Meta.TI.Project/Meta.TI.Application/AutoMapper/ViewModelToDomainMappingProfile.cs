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
        }
    }
}
