﻿// <auto-generated />
using Meta.TI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Meta.TI.Infra.Data.Migrations
{
    [DbContext(typeof(MetaTiContext))]
    [Migration("20200516171104_TipoSanguineo")]
    partial class TipoSanguineo
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

            modelBuilder.Entity("Meta.TI.Domain.Models.TipoLogin", b =>
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

                    b.Property<bool>("SenhaObrigatoria")
                        .HasColumnName("SenhaObrigatoria")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("TipoLogin");
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
#pragma warning restore 612, 618
        }
    }
}
