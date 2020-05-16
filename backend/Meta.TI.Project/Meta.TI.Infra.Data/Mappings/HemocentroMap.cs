using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Infra.Data.Mappings
{
    public class HemocentroMap : IEntityTypeConfiguration<Hemocentro>
    {
        public void Configure(EntityTypeBuilder<Hemocentro> builder)
        {
            builder.Property(h => h.Id)                
                .HasColumnName("Id");

            builder.Property(h => h.Nome)
                .HasColumnType("varchar(255)")
                .HasColumnName("Nome")
                .IsRequired();

            builder.Property(h => h.CNPJ)
                .HasColumnType("varchar(14)")
                .HasColumnName("CNPJ");

            builder.Property(h => h.Aprovado)
                .HasColumnType("bit")
                .HasColumnName("Aprovado")
                .IsRequired();

            builder.Property(h => h.Ativo)
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

            builder.HasOne(u => u.Endereco)
               .WithOne(t => t.Hemocentro)
               .HasForeignKey<Hemocentro>(t => t.IdEndereco);

        }
    }
}
