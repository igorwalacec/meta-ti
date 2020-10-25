using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meta.TI.Infra.Data.Mappings
{
    public class PatrocinadorMap : IEntityTypeConfiguration<Patrocinador>
    {
        public void Configure(EntityTypeBuilder<Patrocinador> builder)
        {
            builder.Property(p => p.Id)
               .ValueGeneratedOnAdd()
               .HasColumnName("Id");

            builder.Property(p => p.NomePatrocinador)
                .HasColumnType("varchar(255)")
                .HasColumnName("NomePatrocinador")
                .IsRequired();

            builder.Property(p => p.Ativo)
                .HasColumnType("bit")
                .HasColumnName("Ativo")
                .IsRequired();

            builder.HasMany(p => p.Recompensas)
                .WithOne(r => r.Patrocinador)
                .HasForeignKey(r => r.IdPatrocinador)
                .IsRequired();
        }
    }
}
