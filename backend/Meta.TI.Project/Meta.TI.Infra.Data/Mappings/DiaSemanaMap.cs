using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Infra.Data.Mappings
{
    public class DiaSemanaMap : IEntityTypeConfiguration<DiaSemana>
    {
        public void Configure(EntityTypeBuilder<DiaSemana> builder)
        {
            builder.Property(d => d.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            builder.Property(d => d.Nome)
                .HasColumnType("varchar(100)")
                .HasColumnName("Nome")
                .IsRequired();

        }
    }
}
