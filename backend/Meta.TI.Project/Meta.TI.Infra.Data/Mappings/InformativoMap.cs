using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meta.TI.Infra.Data.Mappings
{
    public class InformativoMap : IEntityTypeConfiguration<Informativo>
    {
        public void Configure(EntityTypeBuilder<Informativo> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(e => e.Titulo)
                .HasColumnType("varchar(2000)")
                .HasColumnName("Titulo")
                .IsRequired();

            builder.Property(e => e.Descricao)
                .HasColumnType("varchar(2000)")
                .HasColumnName("Descricao")
                .IsRequired();
        }

    }
}
