using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Infra.Data.Mappings
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(e => e.Logradouro)
                .HasColumnType("varchar(255)")
                .HasColumnName("Logradouro")
                .IsRequired();

            builder.Property(e => e.Complemento)
                .HasColumnType("varchar(255)")
                .HasColumnName("Complemento");

            builder.Property(e => e.Numero)
                .HasColumnType("varchar(50)")
                .HasColumnName("Numero")
                .IsRequired();

            builder.Property(e => e.Cep)
                .HasColumnName("varchar(50)")
                .HasColumnName("Cep")
                .IsRequired();

            builder.Property(e => e.Latitude)
                .HasColumnName("varchar(255)")
                .HasColumnName("Latitude");

            builder.Property(e => e.Longitude)
                .HasColumnName("varchar(255)")
                .HasColumnName("Longitude");

            builder.HasOne(e => e.Cidade)
                .WithMany(e => e.Enderecos)
                .HasForeignKey(e => e.IdCidade)
                .IsRequired();          
        }
    }
}
