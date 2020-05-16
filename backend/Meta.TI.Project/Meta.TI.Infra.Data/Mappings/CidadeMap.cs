using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Infra.Data.Mappings
{
    public class CidadeMap : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(e => e.Nome)
                .HasColumnType("varchar(255)")
                .HasColumnName("Nome")
                .IsRequired();
           
            builder.HasOne(e => e.Estado)
                .WithMany(e => e.Cidades)
                .HasForeignKey(e => e.IdEstado)
                .IsRequired();

            builder.HasMany(e => e.Enderecos)
                .WithOne(e => e.Cidade)
                .IsRequired();
        }
    }
}
