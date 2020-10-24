using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meta.TI.Infra.Data.Mappings
{
    public class RecompensasMap : IEntityTypeConfiguration<Recompensas>
    {
        public void Configure(EntityTypeBuilder<Recompensas> builder)
        {
            builder.Property(r => r.Id)
               .ValueGeneratedOnAdd()
               .HasColumnName("Id");

            builder.Property(r => r.Descricao)
                .HasColumnType("varchar(255)")
                .HasColumnName("Descricao")
                .IsRequired();

            builder.Property(r => r.IdPatrocinador)
                .HasColumnType("int")
                .HasColumnName("IdPatrocinador")
                .IsRequired();

            builder.Property(r => r.Ativo)
                .HasColumnType("bit")
                .HasColumnName("Ativo")
                .IsRequired();

            builder.HasOne(r => r.Patrocinador)
                .WithMany(p => p.Recompensas)
                .HasForeignKey(r => r.IdPatrocinador)
                .IsRequired();
        }
    }
}
