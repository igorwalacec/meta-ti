using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meta.TI.Infra.Data.Mappings
{
    public class LevelMap : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.Property(l => l.Id)
               .ValueGeneratedOnAdd()
               .HasColumnName("Id");

            builder.Property(l => l.Nivel)
                .HasColumnType("int")
                .HasColumnName("Nivel")
                .IsRequired();

            builder.Property(l => l.QuantidadeDoacao)
                .HasColumnType("int")
                .HasColumnName("QuantidadeDoacao")
                .IsRequired();

            builder.Property(l => l.IdRecompensa)
                .HasColumnType("int")
                .HasColumnName("IdRecompensas")
                .IsRequired();

            builder.Property(l => l.Ativo)
                .HasColumnType("bit")
                .HasColumnName("Ativo")
                .IsRequired();

            builder.HasOne(l => l.Recompensa)
                .WithOne(r => r.Level)
                .HasForeignKey<Level>(l => l.IdRecompensa)
                .IsRequired();
        }
    }
}
