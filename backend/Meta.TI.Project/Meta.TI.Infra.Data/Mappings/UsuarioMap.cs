using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Meta.TI.Infra.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(u => u.Id)
                .HasColumnName("Id");

            builder.Property(u => u.Nome)
                .HasColumnType("varchar(255)")
                .HasColumnName("Nome")
                .IsRequired();

            builder.Property(u => u.Sobrenome)
                .HasColumnType("varchar(255)")
                .HasColumnName("Sobrenome")
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnType("varchar(255)")
                .HasColumnName("Email")
                .IsRequired();


            builder.Property(u => u.Senha)
                .HasColumnType("varchar(255)")
                .HasColumnName("Senha")
                .IsRequired();

            builder.Property(u => u.RG)
                .HasColumnType("varchar(255)")
                .HasColumnName("RG")
                .IsRequired();

            builder.Property(u => u.CPF)
                .HasColumnType("varchar(255)")
                .HasColumnName("CPF")
                .IsRequired();

            builder.Property(u => u.DataNascimento)
                .HasColumnType("datetime")
                .HasColumnName("DataNascimento")
                .IsRequired();

            builder.Property(u => u.Ativo)
                .HasColumnType("bit")
                .HasColumnName("Ativo")
                .IsRequired();

            builder.Property(u => u.DataCriacao)
                .HasColumnType("datetime")
                .HasColumnName("DataCriacao")
                .IsRequired();


            builder.Property(u => u.DataAlteracao)
                .HasColumnType("datetime")
                .HasColumnName("DataAlteracao");

            builder.HasOne(u => u.TipoSanguineo)
                .WithOne(t => t.Usuario)
                .HasForeignKey<Usuario>(t => t.IdTipoSanguineo);

            builder.HasOne(u => u.Endereco)
                .WithOne(t => t.Usuario)
                .HasForeignKey<Usuario>(t => t.IdEndereco);
        }
    }
}
