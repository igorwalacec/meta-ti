using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Infra.Data.Mappings
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.Property(f => f.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(f => f.NomeCompleto)
                .HasColumnType("varchar(255)")
                .HasColumnName("NomeCompleto")
                .IsRequired();

            builder.Property(f => f.Email)
                .HasColumnType("varchar(255)")
                .HasColumnName("Email")
                .IsRequired();

            builder.Property(f => f.Senha)
                .HasColumnType("varchar(500)")
                .HasColumnName("Senha")
                .IsRequired();

            builder.Property(f => f.CPF)
                .HasColumnType("varchar(11)")
                .HasColumnName("CPF")
                .IsRequired();

            builder.Property(f => f.Ativo)
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


            builder.HasOne(f => f.Hemocentro)
                .WithMany(f => f.Funcionarios)
                .HasForeignKey(f => f.IdHemocentro);
        }
    }
}
