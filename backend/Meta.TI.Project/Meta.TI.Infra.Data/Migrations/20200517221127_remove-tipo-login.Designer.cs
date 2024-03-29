﻿// <auto-generated />
using System;
using Meta.TI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Meta.TI.Infra.Data.Migrations
{
    [DbContext(typeof(MetaTiContext))]
    [Migration("20200517221127_remove-tipo-login")]
    partial class removetipologin
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Meta.TI.Domain.Models.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("IdEstado");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("Meta.TI.Domain.Models.DiaSemana", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("DiaSemana");
                });

            modelBuilder.Entity("Meta.TI.Domain.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnName("Cep")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Complemento")
                        .HasColumnName("Complemento")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("IdCidade")
                        .HasColumnType("int");

                    b.Property<string>("Latitude")
                        .HasColumnName("Latitude")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnName("Logradouro")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Longitude")
                        .HasColumnName("Longitude")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnName("Numero")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdCidade");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("Meta.TI.Domain.Models.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("Meta.TI.Domain.Models.EstoqueSanguineo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("IdHemocentro")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IdTipoSanguineo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdHemocentro");

                    b.HasIndex("IdTipoSanguineo");

                    b.ToTable("EstoqueSanguineo");
                });

            modelBuilder.Entity("Meta.TI.Domain.Models.Expediente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdDiaSemana")
                        .HasColumnType("int");

                    b.Property<Guid>("IdHemocentro")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IdDiaSemana");

                    b.HasIndex("IdHemocentro");

                    b.ToTable("Expediente");
                });

            modelBuilder.Entity("Meta.TI.Domain.Models.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnName("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnName("CPF")
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnName("DataAlteracao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnName("DataCriacao")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("varchar(255)");

                    b.Property<Guid?>("IdHemocentro")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnName("NomeCompleto")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnName("Senha")
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("IdHemocentro");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("Meta.TI.Domain.Models.FuncionarioAdmin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("IdFuncionario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdHemocentro")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IdFuncionario")
                        .IsUnique();

                    b.HasIndex("IdHemocentro");

                    b.ToTable("FuncionarioAdmin");
                });

            modelBuilder.Entity("Meta.TI.Domain.Models.Hemocentro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Aprovado")
                        .HasColumnName("Aprovado")
                        .HasColumnType("bit");

                    b.Property<bool>("Ativo")
                        .HasColumnName("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("CNPJ")
                        .HasColumnName("CNPJ")
                        .HasColumnType("varchar(14)");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnName("DataAlteracao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnName("DataCriacao")
                        .HasColumnType("datetime");

                    b.Property<int>("IdEndereco")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("IdEndereco")
                        .IsUnique();

                    b.ToTable("Hemocentro");
                });

            modelBuilder.Entity("Meta.TI.Domain.Models.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("IdHemocentro")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnName("Numero")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdHemocentro");

                    b.ToTable("Telefone");
                });

            modelBuilder.Entity("Meta.TI.Domain.Models.TipoSanguineo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TipoSanguineo");
                });

            modelBuilder.Entity("Meta.TI.Domain.Models.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnName("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnName("CPF")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnName("DataAlteracao")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnName("DataCriacao")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("IdEndereco")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoLogin")
                        .HasColumnType("int");

                    b.Property<int?>("IdTipoSanguineo")
                        .HasColumnType("int");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasColumnName("NomeCompleto")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasColumnName("RG")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Senha")
                        .HasColumnName("Senha")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("IdEndereco")
                        .IsUnique();

                    b.HasIndex("IdTipoSanguineo")
                        .IsUnique()
                        .HasFilter("[IdTipoSanguineo] IS NOT NULL");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Meta.TI.Domain.Models.Cidade", b =>
                {
                    b.HasOne("Meta.TI.Domain.Models.Estado", "Estado")
                        .WithMany("Cidades")
                        .HasForeignKey("IdEstado")
                        .IsRequired();
                });

            modelBuilder.Entity("Meta.TI.Domain.Models.Endereco", b =>
                {
                    b.HasOne("Meta.TI.Domain.Models.Cidade", "Cidade")
                        .WithMany("Enderecos")
                        .HasForeignKey("IdCidade")
                        .IsRequired();
                });

            modelBuilder.Entity("Meta.TI.Domain.Models.EstoqueSanguineo", b =>
                {
                    b.HasOne("Meta.TI.Domain.Models.Hemocentro", "Hemocentro")
                        .WithMany("EstoquesSanguineos")
                        .HasForeignKey("IdHemocentro")
                        .IsRequired();

                    b.HasOne("Meta.TI.Domain.Models.TipoSanguineo", "TipoSanguineo")
                        .WithMany("EstoquesSanguineos")
                        .HasForeignKey("IdTipoSanguineo")
                        .IsRequired();
                });

            modelBuilder.Entity("Meta.TI.Domain.Models.Expediente", b =>
                {
                    b.HasOne("Meta.TI.Domain.Models.DiaSemana", "DiaSemana")
                        .WithMany("Expedientes")
                        .HasForeignKey("IdDiaSemana")
                        .IsRequired();

                    b.HasOne("Meta.TI.Domain.Models.Hemocentro", "Hemocentro")
                        .WithMany("Expedientes")
                        .HasForeignKey("IdHemocentro")
                        .IsRequired();
                });

            modelBuilder.Entity("Meta.TI.Domain.Models.Funcionario", b =>
                {
                    b.HasOne("Meta.TI.Domain.Models.Hemocentro", "Hemocentro")
                        .WithMany("Funcionarios")
                        .HasForeignKey("IdHemocentro");
                });

            modelBuilder.Entity("Meta.TI.Domain.Models.FuncionarioAdmin", b =>
                {
                    b.HasOne("Meta.TI.Domain.Models.Funcionario", "Funcionario")
                        .WithOne("FuncionarioAdmin")
                        .HasForeignKey("Meta.TI.Domain.Models.FuncionarioAdmin", "IdFuncionario")
                        .IsRequired();

                    b.HasOne("Meta.TI.Domain.Models.Hemocentro", "Hemocentro")
                        .WithMany("FuncionariosAdmin")
                        .HasForeignKey("IdHemocentro")
                        .IsRequired();
                });

            modelBuilder.Entity("Meta.TI.Domain.Models.Hemocentro", b =>
                {
                    b.HasOne("Meta.TI.Domain.Models.Endereco", "Endereco")
                        .WithOne("Hemocentro")
                        .HasForeignKey("Meta.TI.Domain.Models.Hemocentro", "IdEndereco")
                        .IsRequired();
                });

            modelBuilder.Entity("Meta.TI.Domain.Models.Telefone", b =>
                {
                    b.HasOne("Meta.TI.Domain.Models.Hemocentro", "Hemocentro")
                        .WithMany("Telefones")
                        .HasForeignKey("IdHemocentro")
                        .IsRequired();
                });

            modelBuilder.Entity("Meta.TI.Domain.Models.Usuario", b =>
                {
                    b.HasOne("Meta.TI.Domain.Models.Endereco", "Endereco")
                        .WithOne("Usuario")
                        .HasForeignKey("Meta.TI.Domain.Models.Usuario", "IdEndereco")
                        .IsRequired();

                    b.HasOne("Meta.TI.Domain.Models.TipoSanguineo", "TipoSanguineo")
                        .WithOne("Usuario")
                        .HasForeignKey("Meta.TI.Domain.Models.Usuario", "IdTipoSanguineo");
                });
#pragma warning restore 612, 618
        }
    }
}
